using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicaxeAttack : MonoBehaviour
{
    public Collider2D picaxeCollider;
    Vector2 rightAttackOffset;

    public float damage = 5;

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
        picaxeCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
        
    }

    public void AttackLeft()
    {
        SetDamage();
        Debug.Log("AttackLeft");
        Debug.Log("Damage set to: " + damage);
        picaxeCollider.enabled = true;
        transform.localPosition = new Vector3(-rightAttackOffset.x, rightAttackOffset.y);
       
    }

    public void StopAttack()
    {
        picaxeCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Rock")
        {
            //Hacer daño al enemigo 
            Resources rock = other.GetComponent<Resources>();
            if (rock != null)
            {
                rock.Health -= damage;
                Debug.Log(rock.Health);
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
