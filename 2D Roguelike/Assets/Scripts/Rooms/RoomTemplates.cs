using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    // Variables
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedPortal;
    public GameObject portal;

    void Update()
    {
        // Spawn portal in end room
        if (waitTime <= 0 && spawnedPortal == false)
        {

            Instantiate(portal, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
            spawnedPortal = true;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
