using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : MonoBehaviour
{
    // Variables
    public float damage = 30f;
    public float lifetime = 20f;


    private void Start()
    {
        Destroy(this.gameObject, lifetime);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.rigidbody.GetComponent<Enemy>().EnemyTakeDamage(damage);
        }
    }



}
