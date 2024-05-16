using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int maxHunger = 10;
    public int currentHunger;

    public HealthBar healthBar;
    public HungerBar hungerBar;
    private Animator animator;
    public bool hasSword = false;
    public bool hasAxe = false;
    public bool hasPico = false;

    public Canvas canvas;

    public float moveSpeed = 1f;
    public ContactFilter2D movementFilter;
    public float collisionOffset = 0.05f;
    public SwordAttack swordAttack;
    public AxeAttack axeAttack;
    public PicaxeAttack picaxeAttack;

    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollitions = new List<RaycastHit2D>();

    bool canMove = true;
    bool nearMaquinaRetro = false;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentHunger = maxHunger;
        hungerBar.SetMaxHunger(maxHunger);

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (canMove)
        {
            if (movementInput != Vector2.zero)
            {
                bool success = TryMove(movementInput);

                if (!success)
                {
                    success = TryMove(new Vector2(movementInput.x, 0));
                }
                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }

                animator.SetBool("isMoving", success);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }

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





    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }
    void IncreaseHunger(int amount)
    {
        currentHunger += amount;
        if (currentHunger > maxHunger)
            currentHunger = maxHunger;
        hungerBar.SetHunger(currentHunger);
    }

    void DecreaseHunger(int amount)
    {
        currentHunger -= amount;
        if (currentHunger < 0)
            currentHunger = 0;
        hungerBar.SetHunger(currentHunger);
    }

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

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire()
    {
        Debug.Log("Click Derecho");
        CheckItemAction();
    }

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
    void PauseAndLoadPCScene()
    {
        Time.timeScale = 0f; // Pausa el juego
        SceneManager.LoadScene("PC", LoadSceneMode.Additive); // Cargar la nueva escena "PC" sin descargar la actual
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
