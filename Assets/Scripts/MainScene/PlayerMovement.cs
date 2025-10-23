using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float climbSpeed = 3f;

    public float jumpForce = 6f;
    private bool isGrounded = true;

    private bool isClimbing = false;
    private Collider2D ladder = null;
    public string climbingLayer = "Climbing";

    public Rigidbody2D rigidbody2d;
    public Collider2D collider2d;
    public Animator animator;

    public Vector2 movement;

    private float gravity;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        gravity = rigidbody2d.gravityScale;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); //ÁÂ¿ì ¿òÁ÷ÀÓ
        animator.SetFloat("Speed", Mathf.Abs(movement.x));

        //Á¡ÇÁ
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isClimbing)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);
            isGrounded = false;
            animator.SetBool("IsJumping", true);
        }
        if (ladder != null && (Input.GetKeyDown(KeyCode.E)))
        {
            if (!isClimbing) StartClimbing();
            else StopClimbing();
        }
        if (isClimbing && ladder == null) StopClimbing();

        if (isClimbing)
        {
            movement.y = Input.GetAxisRaw("Vertical");
        }
    }
    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rigidbody2d.velocity = new Vector2(0, movement.y * climbSpeed);
        }
        else
        {
            //°È±â ¶Ù±â
            bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            float currentSpeed = isRunning && isGrounded ? runSpeed : walkSpeed;
            rigidbody2d.velocity = new Vector2(movement.x * currentSpeed, rigidbody2d.velocity.y);
            isGrounded = IsGrounded();
            if (isGrounded) animator.SetBool("IsJumping", false);
        }
    }
    private void LateUpdate()
    {
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -9f, 15f);
        transform.position = pos;
    }
    private bool IsGrounded()
    {
        Debug.DrawRay(rigidbody2d.position, Vector2.down, new Color(1, 0, 0));
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position, Vector2.down, 1f, LayerMask.GetMask("Platform"));
        return hit.collider != null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            ladder = collision;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            {
                if (ladder == collision) ladder = null;
            }
        }
    }
    private void StartClimbing()
    {
        isClimbing = true;
        rigidbody2d.velocity = Vector2.zero;
        rigidbody2d.gravityScale = 0;
        gameObject.layer = LayerMask.NameToLayer(climbingLayer);
    }
    private void StopClimbing()
    {
        isClimbing = false;
        rigidbody2d.gravityScale = gravity;
        movement.y = 0;
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }
}
