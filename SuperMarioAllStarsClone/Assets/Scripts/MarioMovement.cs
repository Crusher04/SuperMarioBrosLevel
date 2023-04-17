using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MarioMovement : MonoBehaviour
{
    [Header("RigidBody Component")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Ground Check Componenets")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Wall Check Componenets")]
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    [Header("Mario Speed")]
    [SerializeField] private float horizontal;
    [SerializeField] private float DefaultSpeed = 6f;
    [SerializeField] private float MaxSpeed = 12f;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float speedModifier = 0.5f;


    [Header("Mario Jumping")]
    [SerializeField] private float jumpingPower = 16f;

    private bool isFacingRight = true;
    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;
    private bool isSprinting = false;
    private Animator anim;


    public float rbXVelTest;
    public float rbYVelTest;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("moving", false);
        anim.SetBool("jumping", false);
        anim.SetBool("flipped", false);
    }

    // Update is called once per frame
    void Update()
    {
        //Reading Rigidbody x velocity to test movement
        rbXVelTest = rb.velocity.x;
        rbYVelTest = rb.velocity.y;

        //Check which way we're facing
        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }

        //Check if moving..
        if (horizontal != 0f)
        {
            if (isSprinting)
            {
                if (speed < MaxSpeed)
                    speed += speedModifier;

                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
                
                
            }
            else
            {
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            }
            anim.SetBool("moving", true);
        }
        else
        {
            if (speed != DefaultSpeed)
                speed = DefaultSpeed;

            anim.SetBool("moving", false);
        }

        //Stop Jumping Animation if on the ground
        if(IsGrounded())
            anim.SetBool("jumping", false);

        //Check for max speed sprinting animation
        if (speed >= MaxSpeed)
        {
            anim.SetBool("sprinting", true);
        }
        else
        {
            anim.SetBool("sprinting", false);
        }

        WallSlide();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        
        if(context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            anim.SetBool("jumping", true);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            anim.SetBool("jumping", true);
        }


    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if(IsWalled() && !IsGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
