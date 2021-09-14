using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    // Variables
    public GameObject[] enemySpawnPoints;
    public GameObject enemy;


    private void Start()
    {
        foreach (GameObject enemySpawnPoint in enemySpawnPoints)
        {
            if (enemySpawnPoint.activeSelf == true)
            {
                int createOrNot = Random.Range(0, 2);
                if (createOrNot == 0)
                    enemy = Instantiate(enemy, enemySpawnPoint.transform.position, enemySpawnPoint.transform.rotation) as GameObject;
            }
        }
    }




}
