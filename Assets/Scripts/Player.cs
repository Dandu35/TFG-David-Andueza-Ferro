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

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentHunger = maxHunger;
        hungerBar.SetMaxHunger(maxHunger);
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            DecreaseHunger(3);
        }
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
            currentHunger = maxHunger; // Asegurarse de que no exceda el máximo
        hungerBar.SetHunger(currentHunger);
    }

    void DecreaseHunger(int amount)
    {
        currentHunger -= amount;
        if (currentHunger < 0)
            currentHunger = 0; // Asegurarse de que no sea menor que cero
        hungerBar.SetHunger(currentHunger);
    }
}
