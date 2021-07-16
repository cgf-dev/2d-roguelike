using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Movement Variables
    public float enemyMoveSpeed;
    public float stoppingDistance;
    public float retreatDistance;

    // Combat Variables
    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public float enemyBulletSpeed = 60f;
    public float enemyHealth = 50f;



    public GameObject enemyBullet;
    public GameObject bulletStart;
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBetweenShots = startTimeBetweenShots;
    }


    void Update()
    {
        #region Movement
        // If closer than stopping distance, move towards player
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, enemyMoveSpeed * Time.deltaTime);
        }
        // If within shooting range, stop moving
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance &&
            (Vector2.Distance(transform.position, player.position) > retreatDistance))
        {
            transform.position = this.transform.position;
        }
        // If too close, run away
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -enemyMoveSpeed * Time.deltaTime);
        }

        // Face player
        Vector3 eDifference = player.position - transform.position;
        float rotationZ = Mathf.Atan2(eDifference.y, eDifference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        float distance = eDifference.magnitude;
        Vector2 direction = eDifference / distance;
        #endregion

        #region Shooting
        // Shoot if ready
        if (timeBetweenShots <= 0)
        {
            GameObject eBullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);
            eBullet.transform.position = bulletStart.transform.position;
            eBullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, (rotationZ + 90));
            eBullet.GetComponent<Rigidbody2D>().velocity = direction * enemyBulletSpeed;

            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
        #endregion

    }

    public void EnemyTakeDamage(float damageToTake)
    {
        enemyHealth -= damageToTake;
        // Colour change
        // Die
    }

}
