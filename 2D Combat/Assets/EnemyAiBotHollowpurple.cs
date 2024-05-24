using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject pillarPrefab;
    public GameObject hollowPurplePrefab;
    public GameObject explosionEffect;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float retreatDistance = 5f;
    public float attackRange = 2f;
    public float pillarCooldown = 5f;
    public float hollowPurpleCooldown = 10f;

    private Rigidbody2D rb;
    private Transform player;
    private bool isFacingRight = true;

    private float nextPillarTime = 0f;
    private float nextHollowPurpleTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Ensure the enemy is always upright
        transform.rotation = Quaternion.Euler(0, 0, 0);

        // Calculate distance to player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Determine behavior based on distance to player
        if (distanceToPlayer <= attackRange)
        {
            Attack();
        }
        else if (distanceToPlayer < retreatDistance)
        {
            RetreatFromPlayer();
        }
        else
        {
            MoveTowardsPlayer();
        }

        // Ensure enemy stays within bounds (optional, adjust to your game boundaries)
        StayWithinBounds();
    }

    void MoveTowardsPlayer()
    {
        float direction = player.position.x - transform.position.x;

        // Move towards player
        rb.velocity = new Vector2(Mathf.Sign(direction) * moveSpeed, rb.velocity.y);

        // Flip sprite if necessary
        if (direction < 0 && isFacingRight || direction > 0 && !isFacingRight)
        {
            Flip();
        }
    }

    void RetreatFromPlayer()
    {
        float direction = transform.position.x - player.position.x;

        // Move away from player
        rb.velocity = new Vector2(Mathf.Sign(direction) * moveSpeed, rb.velocity.y);

        // Flip sprite if necessary
        if (direction < 0 && !isFacingRight || direction > 0 && isFacingRight)
        {
            Flip();
        }
    }

    void Attack()
    {
        // Attack logic
        if (Time.time >= nextPillarTime)
        {
            SpawnPillar();
            nextPillarTime = Time.time + pillarCooldown;
        }

        if (Time.time >= nextHollowPurpleTime)
        {
            SpawnHollowPurple();
            nextHollowPurpleTime = Time.time + hollowPurpleCooldown;
        }

        // Optional: Add a jump attack with cooldown
        if (Time.time >= nextPillarTime)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            nextPillarTime = Time.time + pillarCooldown;
        }
    }

    void SpawnPillar()
    {
        Instantiate(pillarPrefab, transform.position, Quaternion.identity);
    }

    void SpawnHollowPurple()
    {
        Instantiate(hollowPurplePrefab, transform.position, Quaternion.identity);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void StayWithinBounds()
    {
        // Implement boundary logic here
        // Example: if enemy goes off the screen, reset position or change direction
        Vector3 position = transform.position;

        // Example boundaries
        float leftBound = -10f;
        float rightBound = 10f;

        if (position.x < leftBound || position.x > rightBound)
        {
            // Reverse direction if hitting bounds
            Flip();
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
