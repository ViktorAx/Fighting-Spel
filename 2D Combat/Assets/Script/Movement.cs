using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] float JumpForce = 3;
    [SerializeField] ContactFilter2D groundFilter;
    Vector2 inputDir = Vector2.zero;
    CapsuleCollider2D coll;
    Rigidbody2D rb;
    bool grounded = false;
    bool jump = false;
    static public bool flip = false; //false=Right true=Left

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        grounded = coll.IsTouching(groundFilter);

        rb.velocity = new Vector2(inputDir.x * speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.A))
        {
            flip = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            flip = false;
        }
        
        if (jump)
        {
            Jump();
        }
    }

    public void SetMoveDir(InputAction.CallbackContext context)
    {
        inputDir = context.ReadValue<Vector2>();
    }

    public void ActivateJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jump = true;
        }
        if (context.performed || context.canceled)
        {
            jump = false;
        }
    }
    private void Jump()
    {
        if (grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            jump = false;
        }
    }

}
