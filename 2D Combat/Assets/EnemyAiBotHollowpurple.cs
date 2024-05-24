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
    private bool isRetreating = false;

    private float nextPillarTime = 0f;
    private float nextHollowPurpleTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Retreat from player if too close
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer < retreatDistance)
        {
            isRetreating = true;
        }
        else
        {
            isRetreating = false;
        }

        // Move towards or away from player
        if (!isRetreating)
        {
            MoveTowardsPlayer();
        }
        else
        {
            RetreatFromPlayer();
        }

        // Check for attack range
        if (distanceToPlayer <= attackRange)
        {
            Attack();
        }
    }

    void MoveTowardsPlayer()
    {
        float horizontalInput = player.position.x - transform.position.x;

        // Move towards player
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Flip if necessary
        if (horizontalInput < 0 && isFacingRight || horizontalInput > 0 && !isFacingRight)
        {
            Flip();
        }
    }

    void RetreatFromPlayer()
    {
        float horizontalInput = transform.position.x - player.position.x;

        // Move away from player
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Flip if necessary
        if (horizontalInput < 0 && !isFacingRight || horizontalInput > 0 && isFacingRight)
        {
            Flip();
        }
    }

    void Attack()
    {
        // Jump if cooldown is over
        if (Time.time >= nextPillarTime)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            nextPillarTime = Time.time + pillarCooldown;
        }

        // Spawn pillar if cooldown is over
        if (Time.time >= nextPillarTime)
        {
            SpawnPillar();
            nextPillarTime = Time.time + pillarCooldown;
        }

        // Spawn Hollow Purple if cooldown is over
        if (Time.time >= nextHollowPurpleTime)
        {
            SpawnHollowPurple();
            nextHollowPurpleTime = Time.time + hollowPurpleCooldown;
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
        transform.Rotate(0f, 180f, 0f);
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
