using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointAndShoot : MonoBehaviour
{

    public GameObject Player;
    public GameObject Crosshair;

    public float fireRateHere = 1f;
    public float nextFire = 0f;
    public float bulletSpeed = 60f;

    public float bigBulletSpeed = 100f;
    public float bigBulletCooldown = 5f;
    public float nextBigBullet = 0f;
    public bool bigBulletReady = true;
    public Slider bigBulletSlider;
    

    private Vector3 target;
    public float rotationZ;
    public GameObject bulletPrefab;
    public GameObject bulletStart;

    public GameObject bigBulletPrefab;


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
        Vector3 difference = target - Player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        // Rotate player to move with crosshair
        Player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        // Check if firerate is sufficient
        fireRateHere = Player.GetComponent<Player>().playerFireRate;

        if ((Input.GetMouseButton(0)) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRateHere;
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            Shoot(direction, rotationZ);
        }

        
        // bigBullet Cooldown
        if (nextBigBullet >= bigBulletCooldown)
        {
            bigBulletReady = true;
        }
        else
        {
            bigBulletReady = false;
            nextBigBullet += Time.deltaTime;
            nextBigBullet = Mathf.Clamp(nextBigBullet, 0f, bigBulletCooldown);
        }

        // Update bigBulletSlider
        bigBulletSlider.value = nextBigBullet / bigBulletCooldown;

        if (Input.GetKeyDown(KeyCode.Space) && bigBulletReady)
        {
            //nextBigBullet = Time.time + bigBulletCooldown;
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            BigBullet(direction, rotationZ);
            nextBigBullet = 0f;
        }

        void Shoot(Vector2 direction, float rotationZ)
        {
            GameObject bullet = Instantiate(bulletPrefab) as GameObject;
            bullet.transform.position = bulletStart.transform.position;
            bullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, (rotationZ + 90));
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }

        void BigBullet(Vector2 direction, float rotationZ)
        {
            GameObject bigBullet = Instantiate(bigBulletPrefab) as GameObject;
            bigBullet.transform.position = bulletStart.transform.position;
            bigBullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, (rotationZ + 90));
            bigBullet.GetComponent<Rigidbody2D>().velocity = direction * bigBulletSpeed;
        }
    }
}
