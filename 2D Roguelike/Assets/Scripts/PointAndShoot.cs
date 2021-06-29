using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{

    public GameObject player;
    public GameObject Crosshair;
    
    private Vector3 target;
    public float rotationZ;
    public GameObject bulletPrefab;
    public float bulletSpeed = 60f;
    public GameObject bulletStart;


    void Start()
    {
        // Hide mouse
        Cursor.visible = false;
    }


    void Update()
    {
        // Find target for crosshair
        target = GetComponent<Camera>().ScreenToWorldPoint
            (new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

        Crosshair.transform.position = new Vector2(target.x, target.y);

        // Find difference between player and crosshair
        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        // ***OPTIONAL*** - Rotate player to move with crosshair
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            Shoot(direction, rotationZ);
        }

        void Shoot(Vector2 direction, float rotationZ)
        {
            GameObject bullet = Instantiate(bulletPrefab) as GameObject;
            bullet.transform.position = bulletStart.transform.position;
            bullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, (rotationZ + 90));
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }
}
