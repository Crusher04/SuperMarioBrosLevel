using System.Collections;
using System.Collections.Generic;

using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    ///Initialize Variables

    
    //Variables for speed
    public float moveSpeed = 1.5f;
    private float newSpeed;
    public float jumpSpeed;

    //Variables for the object
    private Rigidbody2D rb;
    private Vector3 localScale;

    //Variables for movement
    private bool moveRight;
    private bool isFlying;
    private bool isJumping;

    //Variables for enemy type
    public bool isKoopa;
    public bool isGoomba;
    public bool isPiranha;
    public bool hasWings;

    //Other Variables
    private int jumpCount;


    // Start is called before the first frame update
    void Start()
    {
        //Get the RigidBody and the scale of the enemy
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();

        //Set the newSpeed to equal moveSpeed at the start
        if (moveRight)
        {

            newSpeed = moveSpeed;

        }
        else
        {

            newSpeed = -moveSpeed;

        }

        //Set these variables to 0
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //IF the enemy does not have wings than have it move right and left
        if (!hasWings)
        {

            //Set enemy velocity 
            rb.velocity = new Vector2(newSpeed, 0);

            //Change velocity depending on if the enemy is moving right or left
            if (moveRight)
            {

                newSpeed = moveSpeed;

            }
            else
            {

                newSpeed = -moveSpeed;

            }
        }

        //Check to see if the enemy is flying
        if (isFlying == false)
        {
            //Check to see if the enemy has wings and if it is a Koopa
            if(hasWings == true && isKoopa)
            {
                //Make the enemy fly     
                rb.velocity = new Vector2(newSpeed / 2, jumpSpeed);
                isFlying = true;
            }


            //Check to see if the enemy has wings and if it is a Goomba
            //Goomba with wings has a different flying pattern than a Koopa with wings
            if (hasWings == true && isGoomba)
            {
                
                //Check to see if it is jumping 
                if (isJumping == true)
                {
                    //Make the enemy jump
                    rb.velocity = new Vector2(newSpeed / 2, jumpSpeed / 3);
                    isJumping = false;
                }
                
                //After 3 jumps make the enemy fly
                if (jumpCount == 3)
                {

                    isJumping = false;
                    rb.velocity = new Vector2(newSpeed / 2, jumpSpeed);
                    isFlying = true;
                    jumpCount = 0;

                }
            }


        }        

    }

    //Function that is called when enemy collides with something
    void OnTriggerEnter2D(Collider2D trigger)
    {

        //IF the enemy does not have wings
        if (!hasWings)
        {
            //Check to see if the enemy collided with a switch object
            if (trigger.gameObject.CompareTag("Switch") || trigger.gameObject.CompareTag("Ground"))
            {
                //IF the enemy was moving right than make the enemy move left instead
                if (moveRight)
                {
                    //Flip the enemy sprite when it changes directions
                    localScale.x *= -1;
                    transform.localScale = localScale;
                    moveRight = false;
                }
                //IF the enemy was moving left than make the enemy move right instead
                else
                {
                    //Flip the enemy sprite when it changes directions
                    localScale.x *= -1;
                    transform.localScale = localScale;
                    moveRight = true;

                }
            }
        }

        //IF the enemy does have wings
        if (hasWings)
        {
            //Check to see if the enemy collided with an edge block or the ground
            if (trigger.gameObject.CompareTag("Edge Block") || trigger.gameObject.CompareTag("Ground"))
            {

                //Set isFlying to false 
                isFlying = false;
                //IF isFlying is false than set isJumping to true
                if (isFlying == false)
                {
                    isJumping = true;

                }
                //Increase Jump Count
                jumpCount++;
            }
        }



    }

}
