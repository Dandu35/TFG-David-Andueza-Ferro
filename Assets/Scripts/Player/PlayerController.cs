using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{
    // Variables públicas para la salud y el hambre
    public int maxHealth = 100;
    public int currentHealth;
    public int maxHunger = 10;
    public int currentHunger;

    // Referencias a otros componentes y objetos
    private WorldTime worldTime;
    public HealthBar healthBar;
    public HungerBar hungerBar;
    private Animator animator;
    public SwordAttack swordAttack;
    public AxeAttack axeAttack;
    public PicaxeAttack picaxeAttack;
   
    // Variables de control de movimiento y estado
    public bool hasSword = false;
    public bool hasAxe = false;
    public bool hasPico = false;
    public Canvas canvas;
    public GameObject pcCanvas;
    private TimeSpan lastDecreaseTime;
    public float moveSpeed = 1f;
    public ContactFilter2D movementFilter;
    public float collisionOffset = 0.05f;
    
    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollitions = new List<RaycastHit2D>();

    bool canMove = true;
    public bool nearMaquinaRetro = false;

    public int healthLossIntervalInSeconds = 3;
    private Coroutine healthLossCoroutine;

    public event EventHandler MuerteJugador;


    void Start()
    {
        // Inicialización de la salud y el hambre
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentHunger = maxHunger;
        hungerBar.SetMaxHunger(maxHunger);
        
        // Obtener referencias a componentes y objetos necesarios
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
       
        // Obtener referencia al objeto WorldTime y suscribir al evento WorldTimeChanged
        GameObject worldTimeObject = GameObject.FindWithTag("WorldTime");
        if (worldTimeObject != null)
        {
            worldTime = worldTimeObject.GetComponent<WorldTime>();
            worldTime.WorldTimeChanged += OnWorldTimeChanged; // Suscribir al evento WorldTimeChanged
        }
        else
        {
            Debug.LogError("No se encontró el objeto con el script WorldTime adjunto.");
        }
        
        // Iniciar la pérdida de salud por hambre si la comida es cero
        if (currentHunger <= 0)
        {
            healthLossCoroutine = StartCoroutine(HealthLossCoroutine());
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            DecreaseHunger(3);
        }
        if (Input.GetKeyDown(KeyCode.E) && nearMaquinaRetro)
        {
            PauseAndLoadPCScene();
        }
    }



    void FixedUpdate()
    {
        // Movimiento del jugador basado en la entrada
        if (canMove)
        {
            // Intentar mover al jugador en la dirección indicada por la entrada
            if (movementInput != Vector2.zero)
            {
                bool success = TryMove(movementInput);

                // Intentar mover en las direcciones X e Y si el movimiento directo falla
                if (!success)
                {
                    success = TryMove(new Vector2(movementInput.x, 0));
                }
                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }

                // Actualizar la animación del jugador en base al movimiento
                animator.SetBool("isMoving", success);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

            // Voltear el sprite del jugador según la dirección del movimiento
            if (movementInput.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
    }


    // Método de destrucción para la limpieza de suscripciones
    void OnDestroy()
    {
        if (worldTime != null)
        {
            worldTime.WorldTimeChanged -= OnWorldTimeChanged; // Darse de baja del evento al destruir el objeto
        }
    }

    // Método invocado cuando cambia el tiempo en el juego
    private void OnWorldTimeChanged(object sender, TimeSpan newTime)
    {
        // Verificar si ha pasado al menos una hora desde el último decremento de la comida
        TimeSpan timeSinceLastDecrease = newTime - lastDecreaseTime;
        if (timeSinceLastDecrease.TotalHours >= 1)
        {
            DecreaseHunger(1); // Reducir la comida en 1 unidad
            lastDecreaseTime = newTime; // Actualizar el tiempo del último decremento
        }
    }
    
    // Corrutina para la pérdida de salud por hambre
    IEnumerator HealthLossCoroutine()
    {
        while (true)
        {
            // Perder vida de 3 en 3
            TakeDamage(3);

            // Esperar el intervalo de tiempo especificado antes de perder más vida
            yield return new WaitForSeconds(healthLossIntervalInSeconds);
        }
    }

    // Método para recibir daño
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0) {
            MuerteJugador?.Invoke(this, EventArgs.Empty);
        }
    }

    // Método para aumentar la salud
    void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    // Método para aumentar el hambre
    void IncreaseHunger(int amount)
    {
        currentHunger += amount;
        if (currentHunger > maxHunger)
            currentHunger = maxHunger;
        hungerBar.SetHunger(currentHunger);
    }

    // Método para disminuir el hambre
    void DecreaseHunger(int amount)
    {
        currentHunger -= amount;
        if (currentHunger < 0)
        {
            currentHunger = 0;
            if (healthLossCoroutine == null)
            {
                // Iniciar la corutina si no se está ejecutando
                healthLossCoroutine = StartCoroutine(HealthLossCoroutine());
            }
        }
        else if (currentHunger > 0 && healthLossCoroutine != null)
        {
            // Detener la corutina si el hambre ya no está en cero
            StopCoroutine(healthLossCoroutine);
            healthLossCoroutine = null;
        }
        hungerBar.SetHunger(currentHunger);
    }

    // Método para intentar mover al jugador
    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            int count = rb.Cast(
                   direction,
                   movementFilter,
                   castCollitions,
                   moveSpeed * Time.fixedDeltaTime + collisionOffset);
            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    // Método invocado cuando se detecta movimiento
    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
    
    // Método invocado cuando se activa la acción de ataque
    void OnFire()
    {
        Debug.Log("Click Derecho");
        CheckItemAction();
    }

    // Método para ejecutar el ataque con espada
    public void SwordAttack()
    {
        Debug.Log("ha entrado ha espada");
        LockMovement();

        if (spriteRenderer.flipX == true)
        {
            swordAttack.AttackLeft();
        }
        else
        {
            swordAttack.AttackRight();
        }
    }
    
    // Método para ejecutar el ataque con pico
    public void PicaxeAttack()
    {
        Debug.Log("ha entrado ha pico");
        LockMovement();

        if (spriteRenderer.flipX == true)
        {
            picaxeAttack.AttackLeft();
        }
        else
        {
            picaxeAttack.AttackRight();
        }
    }

    // Método para ejecutar el ataque con hacha
    public void AxeAttack()
    {
        Debug.Log("ha entrado ha hacha");
        LockMovement();

        if (spriteRenderer.flipX == true)
        {
            axeAttack.AttackLeft();
        }
        else
        {
            axeAttack.AttackRight();
        }
    }
    // Métodos para finalizar ataques
    public void EndSwordAttack()
    {
        UnlockMovement();
        swordAttack.StopAttack();
    }
    public void EndPicaxeAttack()
    {
        UnlockMovement();
        picaxeAttack.StopAttack();
    }
    public void EndAxeAttack()
    {
        UnlockMovement();
        axeAttack.StopAttack();
    }

    public void LockMovement()
    {
        canMove = false;
    }
    public void UnlockMovement()
    {
        canMove = true;
    }

    // Método para realizar la acción del ítem seleccionado
    void CheckItemAction()
    {
        Item currentItem = InventoryManager.instance.GetSelectedItem();
        Debug.Log(currentItem);
        Debug.Log(currentItem.actionType);
        switch (currentItem.actionType)
        {
            case ActionType.Attack:
                animator.SetTrigger("swordAttack");
                break;
            case ActionType.Mine:
                animator.SetTrigger("picaxeAttack");
                break;
            case ActionType.Dig:
                animator.SetTrigger("axeAttack");
                break;
            case ActionType.Healing:
                if (currentHealth < maxHealth) // Verificar si la salud no está al máximo
                {
                    IncreaseHealth(currentItem.healingAmount);
                    InventoryManager.instance.RemoveItem(currentItem); // Eliminar el ítem del inventario
                }
                else
                {
                    Debug.Log("¡Tu salud ya está al máximo!");
                }
                break;
            case ActionType.Eaten:
                if (currentHunger < maxHunger) // Verificar si el hambre no está al máximo
                {
                    IncreaseHunger(currentItem.hungerRestoration);
                    InventoryManager.instance.RemoveItem(currentItem); // Eliminar el ítem del inventario
                }
                else
                {
                    Debug.Log("¡No tienes hambre!");
                }
                break;
            default:
                break;
        }
    }

    // Método para pausar el juego y cargar la escena del PC
    void PauseAndLoadPCScene()
    {
        Time.timeScale = 0; // Pausa el juego
        pcCanvas.SetActive(true);  
    }

    // Detectar colisiones con MaquinaRetro
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MaquinaRetro"))
        {  
            nearMaquinaRetro = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MaquinaRetro"))
        {
            nearMaquinaRetro = false;
        }
    }
}
