using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject enemy;
    public float enemySpawnFixedTimeInterval;


    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            Instantiate(enemy, spawnPoint.position, Quaternion.identity).transform.SetParent(transform);
            yield return new WaitForSeconds(enemySpawnFixedTimeInterval);
        }
    }
}








