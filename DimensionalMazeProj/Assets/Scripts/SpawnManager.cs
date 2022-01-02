using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject enemy;
    [SerializeField] float time;
    [SerializeField] float repeatRate;
    private int numOfEnemies;
    void Start()
    {
        numOfEnemies = 0;
    }
    void Update()
    {
        if (numOfEnemies < 5)
        {
            Invoke("SpawnEnemies", 5f);
            numOfEnemies++;
        }
    }

    void SpawnEnemies()
    {
        Instantiate(enemy, spawnPoint.position, Quaternion.identity).transform.SetParent(transform);
    }
}