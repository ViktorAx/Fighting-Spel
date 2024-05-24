using UnityEngine;
using UnityEngine.InputSystem;

public class movement2 : MonoBehaviour
{
    [SerializeField] ContactFilter2D groundFilter;

    public float moveSpeed;
    public float jumpForce;

    public KeyCode jump;
    bool isJumping;
    bool isGrounded;

    static public bool flip = false; // false=Right true=Left

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = rb.IsTouching(groundFilter);

        float horizontalInput = 0f;

        // Move left
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1f;
        }
        // Move right
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1f;
        }

        // Move the character
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Flip the character if moving left or right
        if (horizontalInput < 0 && !flip || horizontalInput > 0 && flip)
        {
            Flip();
        }

        // Jump
        if (Input.GetKeyDown(jump) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }

        // Update animator parameters
        UpdateAnimator(horizontalInput);
    }

    void Flip()
    {
        // Flip the character horizontally
        flip = !flip;
        transform.Rotate(0f, 180f, 0f);
    }

    void UpdateAnimator(float horizontalInput)
    {
        // Set animator parameters based on input and states
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput)); // Set speed parameter
        animator.SetBool("isJumping", !isGrounded); // Set isJumping parameter

        if (horizontalInput != 0)
        {
            animator.SetFloat("Direction", horizontalInput); // Set direction parameter
        }
    }

    public void ActivateJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isJumping = true;
        }
        if (context.performed || context.canceled)
        {
            isJumping = false;
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
