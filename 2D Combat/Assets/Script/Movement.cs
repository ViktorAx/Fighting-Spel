using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] ContactFilter2D groundFilter;

    public float moveSpeed;
    public float jumpForce;

    public KeyCode jump;

    bool isJumping;
    bool isGrounded;

    static public bool flip = false; // false=Right true=Left

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = rb.IsTouching(groundFilter);

        float horizontalInput = 0f;

        // Move left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1f;
        }
        // Move right
        else if (Input.GetKey(KeyCode.RightArrow))
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
    }

    void Flip()
    {
        // Flip the character horizontally
        flip = !flip;
        transform.Rotate(0f, 180f, 0f);
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

    public void Death()
    {
        Destroyed();
    }

    private void Destroyed()
    {

        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }
}




    //[SerializeField] float speed = 3;
    //[SerializeField] float JumpForce = 3;
    //[SerializeField] ContactFilter2D groundFilter;
    //Vector2 inputDir = Vector2.zero;
    //CapsuleCollider2D coll;
    //Rigidbody2D rb;
    //bool grounded = false;
    //bool jump = false;
    //static public bool flip = false; //false=Right true=Left

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    coll = GetComponent<CapsuleCollider2D>();
    //}

    //void Update()
    //{
    //    grounded = coll.IsTouching(groundFilter);

    //    rb.velocity = new Vector2(inputDir.x * speed, rb.velocity.y);

    //    if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        flip = true;
    //    }
    //    else if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        flip = false;
    //    }   

    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        Jump();
    //    }
    //}

    //public void SetMoveDir(InputAction.CallbackContext context)
    //{
    //    inputDir = context.ReadValue<Vector2>();
    //}

    //public void ActivateJump(InputAction.CallbackContext context)
    //{
    //    if (context.started)
    //    {
    //        jump = true;
    //    }
    //    if (context.performed || context.canceled)
    //    {
    //        jump = false;
    //    }
    //}
    //private void Jump()
    //{
    //    if (grounded)
    //    {
    //        rb.velocity = new Vector2(rb.velocity.x, 0);
    //        rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    //        jump = false;
    //    }
    //}




