using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    // Variables 
    // 1 = need bottom door
    // 2 = need top door
    // 3 = need left door
    // 4 = need right door
    public int openingDirection;

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;


    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("SpawnRoom", 1f);
    }

    private void SpawnRoom()
    {
        if (spawned == false)
        {
            //switch (openingDirection)
            //{
            //    case 1:
            //        // Need to spawn a room with a BOTTOM door
            //        rand = Random.Range(0, templates.bottomRooms.Length);
            //        Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            //        break;
            //    case 2:
            //        // Need to spawn a room with a TOP door
            //        rand = Random.Range(0, templates.topRooms.Length);
            //        Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            //        break;
            //    case 3:
            //        // Need to spawn a room with a LEFT door
            //        rand = Random.Range(0, templates.leftRooms.Length);
            //        Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            //        break;
            //    case 4:
            //        // Need to spawn a room with a RIGHT door
            //        rand = Random.Range(0, templates.rightRooms.Length);
            //        Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            //        break;
            //}

            if (openingDirection == 1)
            {
                // Need to spawn a room with a BOTTOM door
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                // Need to spawn a room with a TOP door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                // Need to spawn a room with a LEFT door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                // Need to spawn a room with a RIGHT door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }           
            spawned = true;
        } 
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            Destroy(gameObject);
        }
    }


}
