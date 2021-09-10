using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public int damage = 10;
    public float lifetime = 10f;

    private void Start()
    {
        Destroy(this.gameObject, lifetime);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        //Player player = other.otherRigidbody.GetComponent<Player>();
        if (other.gameObject.tag == "Player")
        {
            other.rigidbody.GetComponent<Player>().PlayerTakeDamage(damage);
            Destroy(this.gameObject);
        }
    }


}
