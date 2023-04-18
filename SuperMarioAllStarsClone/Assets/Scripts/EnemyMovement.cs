using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

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
    public Transform playerTransform;
    public Transform enemyTransform;
    public EnemyTakeDamage enemyDamageScript;
    //Variables for movement
    public bool moveRight;
    private bool isFlying;
    private bool isJumping;
    public bool enemyTookDamage;

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
        enemyDamageScript = GetComponent<EnemyTakeDamage>();

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
        rb.velocity = new Vector2(0, 0);
    }


    // Update is called once per frame
    void Update()
    {
        
    



        //IF the enemy does not have wings than have it move right and left
        if (!hasWings && !enemyTookDamage && !isPiranha)
        {

            //Set enemy velocity 
            rb.velocity = new Vector2(newSpeed, rb.velocity.y);

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
        if (!hasWings && !enemyTookDamage && !isPiranha)
        {
            //Check to see if the enemy collided with a switch object
            if (trigger.gameObject.CompareTag("Switch"))
            {
                if (!enemyDamageScript.koopaShellMoving)
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

        }

  


    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        //IF the enemy does have wings
        if (hasWings)
        {
            //Check to see if the enemy collided with an edge block or the ground
            if (collision.gameObject.CompareTag("Edge Block") || collision.gameObject.CompareTag("Ground"))
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

        //Check to see if the enemy collided with a switch object
        if (!collision.gameObject.CompareTag("Player"))
        {

            // Get the contact point of the collision
            ContactPoint2D contact = collision.contacts[0];

            // Get the position of the contact point in world coordinates
            Vector2 contactPos = contact.point;

            // Get the normal vector of the collision
            Vector2 contactNormal = contact.normal;

            // Get the game object that collided with this one
            GameObject otherObject = collision.gameObject;


            //Check to see IF the enemy collides with another object
            if (contactPos.y < otherObject.transform.position.y || contactPos.y > otherObject.transform.position.y)
            {

                if (!hasWings)
                {
                    //IF the enemy was moving right than make the enemy move left instead
                    if (moveRight)
                    {
                        //Flip the enemy sprite when it changes directions
                        localScale.x *= -1;
                        transform.localScale = localScale;
                        //rb.velocity = new Vector2(rb.velocity.x, -10);
                        moveRight = false;
                        
                    }
                    //IF the enemy was moving left than make the enemy move right instead
                    else
                    {
                        //Flip the enemy sprite when it changes directions
                        localScale.x *= -1;
                        transform.localScale = localScale;
                        //rb.velocity = new Vector2(rb.velocity.x, -10);
                        moveRight = true;

                    }
   
                }
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Get the contact point of the collision
            ContactPoint2D contact = collision.contacts[0];

            // Get the position of the contact point in world coordinates
            Vector2 contactPos = contact.point;

            // Get the normal vector of the collision
            Vector2 contactNormal = contact.normal;

            // Get the game object that collided with this one
            GameObject otherObject = collision.gameObject;

            EnemyTakeDamage damageScript = collision.gameObject.GetComponent<EnemyTakeDamage>();

            EnemyMovement movementScript = collision.gameObject.GetComponent<EnemyMovement>();
            //Check to see IF the enemy collides with another object
            if (contactPos.y < otherObject.transform.position.y || contactPos.y > otherObject.transform.position.y)
            {


                if (enemyDamageScript.koopaShellMoving)
                {
                    //if (movementScript.hasWings)
                    //{

                    //    movementScript.hasWings = false;
                    //}

                    Destroy(otherObject);


                    damageScript.enemyDamage = true;

                }


            }

        }

    }
}
