using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed;
    public float jumpForce;
    public float climbSpeed;
    Rigidbody2D rb;

    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    public float rememberGroundFor;
    float lastTimeGrounded;

    public float distance;
    public LayerMask whatIsLadder;
    private bool isClimbing;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckIfGrounded();
        Move();
        Climb();
    }
   
    void Move()
    {
        Vector3 movement = new Vector3(Input.acceleration.x, 0f, 0f);
        rb.velocity = movement * moveSpeed;
    }

    public void Jump()
    {
        /*if (Input.GetMouseButtonDown(0) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundFor))
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }*/
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void Climb()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);
        if(hitInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                isClimbing = true;
            }
        }
        else
        {
            isClimbing = false;
        }

        if(isClimbing == true)
        {
            float inputVertical = Input.GetAxisRaw("Vertical");
            float climbBy = inputVertical * climbSpeed;
            rb.velocity = new Vector2(rb.velocity.x, climbBy);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 5;
        }
    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);

        if(collider != null)
        {
            isGrounded = true;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }

    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}