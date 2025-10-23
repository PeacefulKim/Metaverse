using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 5f;

    public float jumpForce = 6f;
    private bool isGrounded = true;

    public Rigidbody2D rigidbody2d;
    public Collider2D collider2d;
    public Vector2 movement;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); //ÁÂ¿ì ¿òÁ÷ÀÓ
        //Á¡ÇÁ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);
            isGrounded = false;
        }

    }
    private void FixedUpdate()
    {
        //°È±â ¶Ù±â
        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        float currentSpeed = isRunning ? runSpeed : walkSpeed;
        rigidbody2d.velocity = new Vector2(movement.x * currentSpeed, rigidbody2d.velocity.y);
        isGrounded = IsGrounded();
    }
    private bool IsGrounded()
    {
        Debug.DrawRay(rigidbody2d.position, Vector2.down, new Color(1, 0, 0));
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position, Vector2.down, 1f, LayerMask.GetMask("Platform"));
        return hit.collider != null;
    }

}
