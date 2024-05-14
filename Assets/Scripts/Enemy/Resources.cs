using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    [SerializeField] private GameObject lootPrefab;
    public Item itemToDrop; // El objeto de botín que quieres dejar caer
    public float health = 1;

    public float Health
    {
        set
        {
            health = value;
            if (health < 0)
            {
                Defeated();
            }
        }
        get
        {
            return health;
        }
    }


    public void Defeated()
    {
        if (lootPrefab != null && itemToDrop != null)
        {
            GameObject loot = Instantiate(lootPrefab, transform.position, Quaternion.identity);
            loot.GetComponent<Loot>().Initialize(itemToDrop);
        }

        Destroy(gameObject);
    }
}
