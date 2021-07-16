using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float damage = 10f;


    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    Enemy enemy = other.GetComponent<Enemy>();
    //    if (enemy != null)
    //    {
    //        Debug.Log("hit!!!");
    //        enemy.EnemyTakeDamage(damage);
    //        Destroy(this.gameObject);
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.rigidbody.GetComponent<Enemy>().EnemyTakeDamage(damage);
            Destroy(this.gameObject);
        }
    }


}
