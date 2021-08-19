using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables

    // Combat Variables
    public int playerHealth = 100;
    public float playerDamage = 10f;
    public float timeToColorOnHit = 0.05f;
    private bool isHit = false;
    public int playerCoins = 0;

    // Movement Variables
    public float moveSpeed;
    private Vector2 moveDirection;

    // Declarations
    private Rigidbody2D rb;
    private PointAndShoot shootScript;

    private SpriteRenderer[] spriteRenderers;
    private Color defaultColor;
    private Color isHitColor;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shootScript = FindObjectOfType<Camera>().GetComponent<PointAndShoot>();

        RefreshSpriteRenderersList();
        defaultColor = this.GetComponent<SpriteRenderer>().color;
        isHitColor = Color.white;
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

    

    public void PlayerTakeDamage(int damageToTake)
    {
        playerHealth -= damageToTake;
        // Colour change
        if (!isHit)
        {
            isHit = true;
            StartCoroutine("SwitchColor");
        }
        // Die
        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


    public void PlayerGainsCoins(int coinsToGive)
    {
        playerCoins += coinsToGive;
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
