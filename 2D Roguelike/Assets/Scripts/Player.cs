using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables

    // Combat Variables
    public float playerHealth = 100f;
    public float playerDamage = 10f;

    // Movement Variables
    public float moveSpeed;
    private Vector2 moveDirection;

    // Declarations
    private Rigidbody2D rb;
    private PointAndShoot shootScript;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shootScript = FindObjectOfType<Camera>().GetComponent<PointAndShoot>();
    }

    void Update()
    {
        PlayerInputs();

        
    }

    void FixedUpdate()
    {
        // Physics
        Movement();
    }

    void PlayerInputs()
    {
        // Movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Movement()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    

    public void PlayerTakeDamage(float damageToTake)
    {
        playerHealth -= damageToTake;
        // Screen shake
        // Colour change
        // Die
    }


}
