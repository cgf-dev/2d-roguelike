using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : MonoBehaviour
{
    // Variables
    public double damage = 30f;
    public float lifetime = 20f;

    private Player player;

    // Bullet Circle
    [Header("Projectile Settings")]
    public int numberOfProjectiles = 5;             // Number of projectiles to shoot
    public float projectileSpeed = 12f;               // Speed of the projectile
    public GameObject Bullet;         // Prefab to spawn

    [Header("Private Variables")]
    private Vector3 startPoint;                 // Starting position of the bullet
    private const float radius = 1F;            // Help us find the move direction


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        StartCoroutine(Die());
        //Destroy(this.gameObject, lifetime);
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.rigidbody.GetComponent<Enemy>().EnemyTakeDamage((float)damage);
        }
    }

    private void EmitBullets()
    {
        startPoint = transform.position;
        SpawnProjectile(numberOfProjectiles);
    }

    // Spawns x number of projectiles.
    private void SpawnProjectile(int _numberOfProjectiles)
    {
        float angleStep = 360f / _numberOfProjectiles;
        float angle = 0f;

        for (int i = 0; i <= _numberOfProjectiles - 1; i++)
        {
            // Direction calculations.
            float projectileDirXPosition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
            float projectileDirYPosition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            // Create vectors.
            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0);
            Vector3 projectileMoveDirection = (projectileVector - startPoint).normalized * projectileSpeed;

            // Create game objects.
            GameObject emittedBullet = Instantiate(Bullet, startPoint, Quaternion.identity);
            emittedBullet.GetComponent<Rigidbody2D>().velocity = new Vector3(projectileMoveDirection.x, 0, projectileMoveDirection.y);

            // Destroy the gameobject after 10 seconds.
            Destroy(emittedBullet, 3F);

            angle += angleStep;
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(lifetime);
        EmitBullets();
        Destroy(this.gameObject);
    }
}
