using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    // Variables
    public bool enteredRoom = false;
    public int enemiesLeft;

    // To Spawn
    public GameObject[] enemySpawnPoints;
    public GameObject enemy;
    public GameObject walls;
    


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            #region Enemies
            // Spawn Enemies
            foreach (GameObject enemySpawnPoint in enemySpawnPoints)
            {
                if (enemySpawnPoint.activeSelf == true)
                {
                    int createOrNot = Random.Range(0, 2);
                    if (createOrNot == 0)
                    {
                        enemy = Instantiate(enemy, enemySpawnPoint.transform.position, enemySpawnPoint.transform.rotation) as GameObject;
                        enemiesLeft++;
                    }    
                }
            }
            #endregion
            #region Walls
            GameObject Walls = Instantiate(walls, transform.position, Quaternion.identity);
            Walls.transform.parent = transform;
            #endregion
        }
    }


    // Count enemies in room
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesLeft--;
            if(enemiesLeft == 0)
            {
                foreach (Transform child in transform)
                {
                    Destroy(GameObject.FindGameObjectWithTag("Walls"));
                }
            }
        }
    }   

}
