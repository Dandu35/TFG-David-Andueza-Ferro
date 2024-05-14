using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAttack : MonoBehaviour
{
    public Collider2D axeCollider;
    Vector2 rightAttackOffset;

    public float damage = 5;

    private void Start()
    {
        rightAttackOffset = transform.position;
    }

    public void AttackRight()
    {
        Debug.Log("AttackRight");
        axeCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft()
    {
        Debug.Log("AttackLeft");
        axeCollider.enabled = true;
        transform.localPosition = new Vector3(-rightAttackOffset.x, rightAttackOffset.y);
    }

    public void StopAttack()
    {
        axeCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Tree")
        {
            //Hacer daño al enemigo 
            Resources tree = other.GetComponent<Resources>();
            if (tree != null)
            {
                tree.Health -= damage;
                Debug.Log(tree.Health);
            }
        }
    }
}
