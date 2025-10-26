using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    FlappyManager flappyManager = null;
    Animator animator = null;
    Rigidbody2D rb = null;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;
    public bool godMode = false;

    void Start()
    {
        flappyManager = FlappyManager.Instance;
        animator = transform.GetComponent<Animator>();
        rb = transform.GetComponent<Rigidbody2D>();

        if (animator == null) Debug.LogError("Animator is null");
        if (rb == null) Debug.LogError("Rigidbody is null");
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            flappyManager.QuitGame();
        }
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    flappyManager.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if (isDead) return;
        Vector3 velocity = rb.velocity;
        velocity.x = forwardSpeed;
        if(isFlap)
        {
            velocity.y = flapForce;
            isFlap = false;
        }
        rb.velocity = velocity;
        float angle = Mathf.Clamp((rb.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;
        if (isDead) return;
        animator.SetInteger("IsDie", 1);
        isDead = true;
        deathCooldown = 1f;
        flappyManager.GameOver();
    }
}
