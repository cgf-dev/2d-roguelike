using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float damage = 10f;


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
