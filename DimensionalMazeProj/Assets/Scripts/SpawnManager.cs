using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject enemy;
    public int numOfEnemies;
    void Start()
    {
        numOfEnemies = 0;
    }
    void Update()
    {
        if (numOfEnemies < 3)
        {
           Spawn1();
        }
    }

    public void Spawn1(){
         //*Invoke("SpawnEnemies", 5f);
            Instantiate(enemy, spawnPoint.position, Quaternion.identity).transform.SetParent(transform);
            numOfEnemies++;
    }
}