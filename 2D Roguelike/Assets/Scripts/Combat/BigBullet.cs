using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : MonoBehaviour
{
    // Variables
    public double damage = 30f;
    public float lifetime = 20f;

    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Destroy(this.gameObject, lifetime);
    }

    private void Update()
    {
        damage = player.playerDamage * 1.5;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.rigidbody.GetComponent<Enemy>().EnemyTakeDamage((float)damage);
        }
    }



}
