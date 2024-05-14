using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicaxeAttack : MonoBehaviour
{
    public Collider2D picaxeCollider;
    Vector2 rightAttackOffset;

    public float damage = 5;

    private void Start()
    {
        rightAttackOffset = transform.position;
    }

    public void AttackRight()
    {
        Debug.Log("AttackRight");
        picaxeCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft()
    {
        Debug.Log("AttackLeft");
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
}
