using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;

    void Start()
    {
        SpawnEnemies();
    }

    public WaveConfigSO GetCurrentWave()
    {

    }

    void SpawnEnemies()
    {
        Instantiate(currentWave.GetEnemyPrefab(0), 
            currentWave.GetStartingWaypoint().position, 
            Quaternion.identity);
    }
}
