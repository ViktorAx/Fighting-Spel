using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement2 : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if(Input.GetKeyDown(jump))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
