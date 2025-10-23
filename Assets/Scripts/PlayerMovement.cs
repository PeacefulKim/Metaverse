using System;
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
    public Animator animator;
    public Vector2 movement;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); //�¿� ������
        animator.SetFloat("Speed",Mathf.Abs(movement.x));
        //����
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpForce);
            isGrounded = false;
            animator.SetBool("IsJumping", true);
        }

    }
    private void FixedUpdate()
    {
        //�ȱ� �ٱ�
        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        float currentSpeed = isRunning && isGrounded ? runSpeed : walkSpeed;
        rigidbody2d.velocity = new Vector2(movement.x * currentSpeed, rigidbody2d.velocity.y);
        isGrounded = IsGrounded();

        if (isGrounded) animator.SetBool("IsJumping", false);
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

}
