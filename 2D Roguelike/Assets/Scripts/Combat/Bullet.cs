using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Variables
    public float damage = 10f;
    public float lifetime = 10f;

    private Player player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Destroy(this.gameObject, lifetime);
    }

    void Update()
    {
        damage = player.playerDamage;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.rigidbody.GetComponent<Enemy>().EnemyTakeDamage(damage);
            Destroy(this.gameObject);
        }
    }


}
