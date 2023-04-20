using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor.AnimatedValues;
using UnityEditor.Experimental.GraphView;
using UnityEditor.U2D;
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
    [SerializeField] private float smallIsGroundOverlap = 0.2f;
    [SerializeField] private float bigIsGroundOverlap = 0.2f;

    [Header("Mario Parent Manager & Game Manager")]
    public PlayerManager parent;
    public GameManager gameManager;

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

    [Header("HUD")]
    public HUD myHUD;

    [SerializeField] private float speedCheck = 0;
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


        HUDSpeedCheck();

        if(transform.position.y < -10)
        {
            parent.marioDead = true;
        }


    }//End of FixedUpdate

    private void HUDSpeedCheck()
    {
        speedCheck = ((rb.velocity.x / 2.4f));
        if (speedCheck < 0)
            speedCheck *= -1;

        if (speedCheck > 2.1)
        {
            myHUD.P1RED.active = true;

            if (speedCheck > 2.54)
            {
                myHUD.P2RED.active = true;

                if (speedCheck > 2.99)
                {
                    myHUD.P3RED.active = true;

                    if (speedCheck > 3.44)
                    {
                        myHUD.P4RED.active = true;

                        if (speedCheck > 3.89)
                        {
                            myHUD.P5RED.active = true;

                            if (speedCheck > 4.34)
                            {
                                myHUD.P6RED.active = true;

                                if (speedCheck > 4.79)
                                {
                                    myHUD.PFinalRED.active = true;
                                    myHUD.GetComponent<AudioSource>().clip = myHUD.PMeterClip;
                                    if (!myHUD.GetComponent<AudioSource>().isPlaying)
                                    {
                                        myHUD.GetComponent<AudioSource>().Play();
                                    }
                                }
                                else
                                {
                                    myHUD.PFinalRED.active = false;
                                    myHUD.GetComponent<AudioSource>().Stop();
                                }
                            }
                            else
                                myHUD.P6RED.active = false;
                        }
                        else
                            myHUD.P5RED.active = false;
                    }
                    else
                        myHUD.P4RED.active = false;
                }
                else
                    myHUD.P3RED.active = false;
            }
            else
                myHUD.P2RED.active = false;
        }
        else
            myHUD.P1RED.active = false;

        if(speedCheck < 2.1)
        {
            myHUD.PFinalRED.active = false;
            myHUD.P6RED.active = false;
            myHUD.P5RED.active = false;
            myHUD.P4RED.active = false;
            myHUD.P3RED.active = false;
            myHUD.P2RED.active = false;
            myHUD.P1RED.active = false;
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
            GetComponent<AudioSource>().Play();
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
        if (parent.marioBig)
            return Physics2D.OverlapCircle(groundCheck.position,bigIsGroundOverlap, groundLayer);
        else
            return Physics2D.OverlapCircle(groundCheck.position, smallIsGroundOverlap, groundLayer);
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
