using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject lootPrefab;
    public Item itemToDrop; // El objeto de botín que quieres dejar caer
    public float health = 1;
    private WorldTime worldTime;
    private int lastDay = 0;

    void Start()
    {
        GameObject worldTimeObject = GameObject.FindWithTag("WorldTime");
        if (worldTimeObject != null)
        {
            worldTime = worldTimeObject.GetComponent<WorldTime>();
            worldTime.WorldTimeChanged += OnWorldTimeChanged;
        }
        else
        {
            Debug.LogError("No se encontró el objeto con el script WorldTime adjunto.");
        }
    }

    void OnDestroy()
    {
        if (worldTime != null)
        {
            worldTime.WorldTimeChanged -= OnWorldTimeChanged;
        }
    }

    private void OnWorldTimeChanged(object sender, System.TimeSpan newTime)
    {
        // Calcular el día actual
        int currentDay = (int)newTime.TotalDays + 1; // Sumamos 1 porque TotalDays empieza en 0

        // Verificar si ha cambiado el día
        if (currentDay != lastDay)
        {
            lastDay = currentDay;
            // Incrementar la vida del enemigo cada día en 3
            Health += 3;
        }
    }



    public float Health { 
        set {
            health = value;
            if (health < 0) {
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
