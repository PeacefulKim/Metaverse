using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    
    public float jumpForce = 4f;
    private bool isGrounded = true;

    public Rigidbody2D rigidbody2d;
    public Vector2 movement;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        float currentSpeed = isRunning ? runSpeed : walkSpeed;
        rigidbody2d.velocity = new Vector2(movement.x * currentSpeed, rigidbody2d.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
