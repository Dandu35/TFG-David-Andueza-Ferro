using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentHunger = maxHunger;
        hungerBar.SetMaxHunger(maxHunger);
        animator = transform.Find("Body").GetComponent<Animator>();
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
        /*if (Input.GetMouseButtonDown(0) && !IsCursorOverInventoryItem(canvas))
        {
            CheckItemAction();
        }*/
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
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

   /* void CheckItemAnimation()
    {
        Item currentItem = InventoryManager.instance.GetSelectedItem();
        Debug.Log(currentItem);

        switch (currentItem.type)
        {
            case ItemType.Espada:
                Debug.Log("Es una espada.");
                hasSword = true;
                break;
            case ItemType.Pico:
                Debug.Log("Es un pico.");
                hasPico = true;
                break;
            case ItemType.Hacha:
                Debug.Log("Es un hacha.");
                hasAxe = true;
                break;
            default:
                animator.SetBool("hasSword", false);
                Debug.Log("No es un tipo de item reconocido.");
                break;
        }
    }*/

   /* void CheckItemAction()
    {
        Item currentItem = InventoryManager.instance.GetSelectedItem();
        Debug.Log(currentItem);
        Debug.Log(currentItem.actionType);
        switch (currentItem.actionType)
        {
            case ActionType.Attack:
                Attack();
                break;
            case ActionType.Mine:
                Mine();
                break;
            case ActionType.Dig:
                Dig();
                break;
            default:
                animator.SetBool("hasSword", false);
                animator.SetBool("Attack", false);
                animator.SetBool("hasPico", false);
                animator.SetBool("Mining", false);
                animator.SetBool("hasAxe", false);
                animator.SetBool("Cuting", false);
                break;
        }
    }

    void Attack()
    {
        Debug.Log("Player is attacking!");
        animator.SetBool("hasSword", true);
        animator.SetBool("Attack", true);
        StartCoroutine(ResetAttackAnimation());
    }

    IEnumerator ResetAttackAnimation()
    {
        yield return new WaitForSeconds(0.5f); // Ajusta este tiempo según la duración de tu animación de ataque
        animator.SetBool("Attack", false);
    }

    void Mine() 
    {
        Debug.Log("Player is mining!");
        animator.SetBool("hasPico", true);
        animator.SetBool("Mining", true);
        StartCoroutine(ResetMiningAnimation());
    }

    IEnumerator ResetMiningAnimation()
    {
        yield return new WaitForSeconds(0.5f); // Ajusta este tiempo según la duración de tu animación de ataque
        animator.SetBool("Mining", false);
    }
    void Dig() 
    {
        Debug.Log("Player is Cuting down a tree!");
        animator.SetBool("hasAxe", true);
        animator.SetBool("Cuting", true);
        StartCoroutine(ResetCutingAnimation());
    }

    IEnumerator ResetCutingAnimation()
    {
        yield return new WaitForSeconds(0.5f); // Ajusta este tiempo según la duración de tu animación de ataque
        animator.SetBool("Cuting", false);
    }

    bool IsCursorOverInventoryItem(Canvas canvas)
    {
        Vector2 cursorPosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(cursorPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.GetComponentInParent<Canvas>() == canvas)
            {
                return true;
            }
        }

        return false;
    }*/
}
