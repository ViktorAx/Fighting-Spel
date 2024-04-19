using System.Collections;
using System.Collections.Generic;
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

    static public bool flip = false; //false=Right true=Left


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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-2, 0);
            flip = true;

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(2, 0);

            flip = false;
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



}
