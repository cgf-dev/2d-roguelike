using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float damage = 10f;
    public float lifetime = 10f;


    private void Start()
    {
        Destroy(this.gameObject, lifetime);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.rigidbody.GetComponent<Enemy>().EnemyTakeDamage(damage);
            Destroy(this.gameObject);
        }
    }


}
