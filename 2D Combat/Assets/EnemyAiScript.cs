using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject explosionEffect;
    public Sprite[] spriteOptions; // Array of sprite options for EnemyBullet
    public float bulletSpeed = 10f;

    private SpriteRenderer spriteRenderer;
    private bool isFacingRight = true;

    void Start()
    {
        // Set sprite renderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Choose a random sprite from the sprite options
        if (spriteOptions.Length > 0)
        {
            int randomIndex = Random.Range(0, spriteOptions.Length);
            spriteRenderer.sprite = spriteOptions[randomIndex];
        }

        // Set initial velocity based on facing direction
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (!isFacingRight)
        {
            rb.velocity = new Vector2(-bulletSpeed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(bulletSpeed, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check collision with player
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        // Check collision with ground or pillar
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Pillar"))
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
