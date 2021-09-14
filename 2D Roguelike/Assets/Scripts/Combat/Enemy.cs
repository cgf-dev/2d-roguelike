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
    public float timeToColorOnHit = 0.05f;
    private bool isHit = false;
    // Loot
    public int coinsToDrop;
    public GameObject Coin;

    // Declarations
    public GameObject enemyBullet;
    public GameObject bulletStart;
    public Transform player;
    private SpriteRenderer[] spriteRenderers;
    private Color defaultColor;
    private Color isHitColor;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBetweenShots = startTimeBetweenShots;

        RefreshSpriteRenderersList();
        defaultColor = this.GetComponent<SpriteRenderer>().color;
        isHitColor = Color.white;
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
        // Colour Change
        if (!isHit)
        {
            isHit = true;
            StartCoroutine("SwitchColor");
        }
        // Die
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            // Drop Coins


            for (int i = 0; i < coinsToDrop; i++)
            {
                Vector2 randomOffset = new Vector2(Random.Range(-0.75f, 0.75f), Random.Range(-0.75f, 0.75f));
                GameObject coin = Instantiate(Coin, randomOffset, transform.rotation);
                randomOffset = new Vector2(Random.Range(-0.75f, 0.75f), Random.Range(-0.75f, 0.75f));
            } 
        }
    }


    private void RefreshSpriteRenderersList()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }


    private IEnumerator SwitchColor()
    {
        foreach (SpriteRenderer r in spriteRenderers)
        {
            r.color = isHitColor;
        }
        yield return new WaitForSeconds(timeToColorOnHit);
        foreach (SpriteRenderer r in spriteRenderers)
        {
            r.color = defaultColor;
        }
        isHit = false;
    }


}
