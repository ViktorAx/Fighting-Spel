using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement2 : MonoBehaviour
{
    [SerializeField] ContactFilter2D groundFilter;

    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    bool isJumping;
    bool isGrounded;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = rb.IsTouching(groundFilter);

        float horizontalInput = 0f;
        if(Input.GetKey(left))
        {
            rb.velocity = new Vector2(-2, 0);

        }
        else if(Input.GetKey(right))
        {
            rb.velocity = new Vector2(2, 0);
        }

        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);



        if (Input.GetKeyDown(jump) && !isJumping)
        {
            if (isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJumping = false;
            }
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


}
