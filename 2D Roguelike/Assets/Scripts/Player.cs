using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Variables

    // Combat Variables
    public int playerHealth = 100;
    public float playerDamage = 10f;
    public float playerFireRate = 1f;
    public float timeToColorOnHit = 0.05f;
    private bool isHit = false;
    public int playerCoins = 0;

    // Movement Variables
    public float moveSpeed;
    private Vector2 moveDirection;

    // Minimap Scaling Variables
    public bool isMapScaled = false;
    public RawImage mapTexture;
    public Image mapBorder;
    public float mapScaleSize = 2f;
    public Camera minimapCamera;

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

        var mapTexture = GameObject.Find("MinimapRenderTexture");
        var mapBorder = GameObject.Find("MinimapBorder");
        var minimapCamera = GameObject.Find("MinimapCamera");
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
        #region Movement
        // Movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
        #endregion

        #region Minimap
        // Minimap Scaling
        if (Input.GetKeyDown(KeyCode.Tab) && isMapScaled == false)
        {
            // Scale Minimap Up
            mapTexture.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 500);
            mapBorder.GetComponent<RectTransform>().sizeDelta = new Vector2(512, 510);
            minimapCamera.orthographicSize = 30;
            isMapScaled = true;

        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isMapScaled == true)
        {
            // Scale Minimap Down
            mapTexture.GetComponent<RectTransform>().sizeDelta = new Vector2(150, 150);
            mapBorder.GetComponent<RectTransform>().sizeDelta = new Vector2(162, 160);
            minimapCamera.orthographicSize = 10;
            isMapScaled = false;
        }
        #endregion
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
