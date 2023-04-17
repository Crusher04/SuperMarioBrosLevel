using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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

    [Header("Skidding Smoke")]
    public GameObject SmokeOne;
    public GameObject SmokeTwo;
    public GameObject SmokeThree;
    public GameObject SmokeFour;
    public Transform SpawnLocation;

    private bool isFacingRight = true;
    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;
    private bool isSprinting = false;
    private Animator anim;

    [Header("Watched Variables")]
    public bool flippingBool;
    public float rbXVelTest;
    public float rbYVelTest;

    private bool jumping = false;
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
    void FixedUpdate()
    {
        //Reading Rigidbody x velocity to test movement
        rbXVelTest = rb.velocity.x;
        rbYVelTest = rb.velocity.y;
        flippingBool = anim.GetBool("flipped");

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
         
            }

            if (horizontal > 0)
            {

                if (rb.velocity.x < 0)
                {
                    anim.SetBool("flipped", true);
                    anim.SetBool("moving", false);
                    anim.SetBool("sprinting", false);
                    speed = DefaultSpeed;
                }
                else
                {
                    anim.SetBool("flipped", false);

                }
            }
            else if (horizontal < 0)
            {
                if (rb.velocity.x > 0)
                {
                    anim.SetBool("flipped", true);
                    anim.SetBool("moving", false);
                    anim.SetBool("sprinting", false);
                    speed = DefaultSpeed;
                }
                else
                {
                    anim.SetBool("flipped", false);
                }
            }

            if (!anim.GetBool("flipped"))
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);



            anim.SetBool("moving", true);
        }
        else
        {
            if (speed != DefaultSpeed)
                speed = DefaultSpeed;

            if (rb.velocity.x != 0)
            {

            }

            anim.SetBool("moving", false);
            anim.SetBool("flipped", false);
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

        if(rb.velocity.y > 0.5f)
        {
            anim.SetBool("jumping", true);
        }
    
    }


    private void SkidSmoke()
    {
        Vector3 spawnPos = SpawnLocation.transform.position;

        
        GameObject spwanSmokeOne = (GameObject)Instantiate(SmokeOne, spawnPos, SpawnLocation.transform.rotation);
        
    }
    private bool isSlowingDown()
    {
        bool areWeMoving = false;
        if(rb.velocity.x != 0)
        {
            areWeMoving = true;
        }
        else
        {
            areWeMoving = false;
        }

        return areWeMoving;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        


        if (context.performed && IsGrounded())
        {    
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {     
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

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
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
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
