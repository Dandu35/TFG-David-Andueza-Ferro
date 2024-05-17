using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    private WorldTime worldTime;
    private int lastDay = 0;

    [SerializeField]
    private int minEnemiesToSpawn = 1;
    [SerializeField]
    private int maxEnemiesToSpawn = 5;
    [SerializeField]
    private float spawnRadius = 5f;

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

    private void OnDestroy()
    {
        if (worldTime != null)
        {
            worldTime.WorldTimeChanged -= OnWorldTimeChanged;
        }
    }

    private void OnWorldTimeChanged(object sender, System.TimeSpan newTime)
    {
        int currentDay = (int)newTime.TotalDays + 1;

        if (currentDay != lastDay)
        {
            lastDay = currentDay;
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        int enemiesToSpawn = Random.Range(minEnemiesToSpawn, maxEnemiesToSpawn + 1);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector3 spawnPosition = transform.position + (Vector3)Random.insideUnitCircle * spawnRadius;
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
