using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float lifetime = 10f;
    public int coinsToGive = 1;

    private void Start()
    {
        Destroy(this.gameObject, lifetime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Player player = other.otherRigidbody.GetComponent<Player>();
        if (other.gameObject.tag == "Player")
        {
            other.rigidbody.GetComponent<Player>().PlayerGainsCoins(coinsToGive);
            Destroy(this.gameObject);
        }
    }
}
