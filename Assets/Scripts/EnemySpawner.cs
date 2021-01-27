using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyController enemy;

    private Vector3 whereToSpawn;
    private float spawnRate = 2f;
    private float nextSpawn = 1.5f;

    private void Update()
    {
        if(Time.timeSinceLevelLoad > nextSpawn)
        {
            Vector3 whereToSpawn = new Vector3(Random.Range(-4200f, 534f), 0, Random.Range(4200f, 534f));
            nextSpawn = Time.timeSinceLevelLoad + spawnRate;
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
            
        }
    }
}
