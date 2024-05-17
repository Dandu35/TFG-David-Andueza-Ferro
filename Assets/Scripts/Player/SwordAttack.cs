using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    
    Vector2 rightAttackOffset;

    public float damage = 3;

    private InventoryManager inventoryManager;

    private void Start()
    {
        rightAttackOffset = transform.position;
        inventoryManager = InventoryManager.instance;
        SetDamage();
    }

    public void AttackRight() 
    {
        SetDamage();
        Debug.Log("AttackRight");
        Debug.Log("Damage set to: " + damage);
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset; 
    }

    public void AttackLeft() 
    {
        SetDamage();
        Debug.Log("AttackLeft");
        Debug.Log("Damage set to: " + damage);
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(-rightAttackOffset.x, rightAttackOffset.y); 
    }

    public void StopAttack() 
    {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            //Hacer daño al enemigo 
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null){
                enemy.Health -= damage;
                Debug.Log(enemy.Health);
            }
        }
    }

    private void SetDamage()
    {
        Item currentItem = inventoryManager.GetSelectedItem();
        if (currentItem != null)
        {
            damage = currentItem.damage;
            Debug.Log("Damage set to: " + damage);
        }
    }
}
