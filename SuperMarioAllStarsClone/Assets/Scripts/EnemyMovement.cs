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
    private float timeLimit;
    private float timeLeft;
    public float time;
    public float waitTime;
    private float piranhaHeightPlus;
    private float piranhaHeightMinus;


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
       
        timeLimit = time;
        timeLeft = timeLimit;
        piranhaHeightPlus = 1000;
        piranhaHeightMinus = -1000;

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;

        //IF the enemy does not have wings than have it move right and left
        if (!hasWings && !enemyTookDamage && !isPiranha)
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

        if (isPiranha)
        {
            if (timeLeft >= 0)
            {
                rb.velocity = new Vector2(0, 2);
                if (rb.position.y >= piranhaHeightPlus)
                {
                    rb.position = new Vector2(rb.position.x, piranhaHeightPlus);

                }

                Vector2 toPlayer = playerTransform.position - enemyTransform.position;
                Vector2 enemyRight = enemyTransform.right;
                // Calculate dot product between toPlayer and enemyRight
                float dotProduct = Vector2.Dot(toPlayer, enemyRight);

                if (dotProduct > 0)
                {
                    localScale.x = -1;
                    transform.localScale = localScale;
                }
                if (dotProduct < 0)
                {
                    localScale.x = 1;
                    transform.localScale = localScale;
                }

            }

            if (timeLeft <= 0f && timeLeft >= -waitTime)
            {
                if (rb.position.y >= piranhaHeightPlus)
                {
                    rb.position = new Vector2(rb.position.x, piranhaHeightPlus);

                }

                piranhaHeightPlus = rb.position.y;
                rb.velocity = new Vector2(0, 0);

            }

            if (timeLeft <= -waitTime && timeLeft >= -time * 2)
            {

                rb.velocity = new Vector2(0, -2);
                if (rb.position.y <= piranhaHeightMinus)
                {
                    
                    rb.position = new Vector2(rb.position.x, piranhaHeightMinus);

                }
            }

            if (timeLeft <= -time * 2)
            {
                if (rb.position.y <= piranhaHeightMinus)
                {

                    rb.position = new Vector2(rb.position.x, piranhaHeightMinus);

                }

                piranhaHeightMinus = rb.position.y;
                rb.velocity = new Vector2(0, 0);

            }

            if (timeLeft <= -waitTime * 3)
            {

                timeLeft = time;

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

            //Check to see IF the enemy collides with another object
            if (contactPos.y < otherObject.transform.position.y || contactPos.y > otherObject.transform.position.y)
            {


                if (enemyDamageScript.koopaShellMoving)
                {

                    damageScript.enemyDamage = true;

                }


            }

        }

    }
}
