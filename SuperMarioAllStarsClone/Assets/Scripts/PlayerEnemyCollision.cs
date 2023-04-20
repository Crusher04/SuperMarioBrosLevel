using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor.Animations;

public class PlayerEnemyCollision : MonoBehaviour
{
    public PlayerManager pmanager;
    public Animator thisAnim;
    public AnimatorController DeathAnim;
    public GameManager gameManager;
    public GameObject Player;

    //Variables for Player
    [SerializeField] private int playerHealth;

    public float moveUp;

    // Start is called before the first frame update
    void Start()
    {

        playerHealth = 1;
       

    }

    // Update is called once per frame
    void Update()
    {
        if(pmanager.marioBig == true)
        {
            playerHealth = 2;
        }
    }



    //Collision for player
    void OnCollisionEnter2D(Collision2D collision)
    {

        bool playerHit;
        bool enemyHit;
        playerHit = false;
        enemyHit = false;
  

        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            if (playerHealth == 2)
            {
                pmanager.marioBig = false;
                pmanager.audioFlag = true;
            }

            Debug.Log("Projectile Hit Mario");
            playerHealth -= 1;
            playerHit = true;
            
           
        }

        //Check to see if the enemy collided with a switch object
        if (collision.gameObject.CompareTag("Enemy"))
        {

            //Audio/shrink mario
            if(playerHealth == 2)
            {
                pmanager.marioBig = false;
                pmanager.audioFlag = true;
            }

            // Get the contact point of the collision
            ContactPoint2D contact = collision.contacts[0];

            // Get the position of the contact point in world coordinates
            Vector2 contactPos = contact.point;

            // Get the normal vector of the collision
            Vector2 contactNormal = contact.normal;

            // Get the game object that collided with this one
            GameObject otherObject = collision.gameObject;

            // Get the script component of the collided object
            EnemyTakeDamage damageScript = collision.gameObject.GetComponent<EnemyTakeDamage>();
            EnemyMovement movementScript = collision.gameObject.GetComponent<EnemyMovement>();

    


            //IF playerHit equals false then check to see if the player collides with the top of an enemy
            if (playerHit == false)
            {
                if (contactPos.y > otherObject.transform.position.y + 0.3)
                {
                    
                    if (movementScript.isPiranha)
                    {

                        playerHealth -= 1;
                        playerHit = true;
                    }

                    if (damageScript.shellCollision)
                    {
                        //Set the enemy's enemyDamage bool to true
                        damageScript.enemyDamage = true;
                        enemyHit = true;
                    }
                }
            }
            
            if (enemyHit == false && damageScript.enemyDeath == false)
            {
                if (damageScript.koopaShellHit > 0)
                {
                    
                    //Check to see IF the player collides with the side of an enemy
                    if (contactPos.x < otherObject.transform.position.x || contactPos.x > otherObject.transform.position.x)
                    {
                        Debug.Log("Hello");
                        //Decrease player health and set playerHit to true
                        playerHealth -= 1;
                        playerHit = true;
                    }
                }
            }

            if (damageScript.koopaShellHit == 0)
            {

               

                if (contactPos.x > otherObject.transform.position.x)
                {
                    damageScript.koopaShellMoving = true;
                    movementScript.moveRight = false;
                    damageScript.audioSource.volume = 0.5f;
                    damageScript.audioSource.PlayOneShot(damageScript.shellKickAudio);
                }

                if (contactPos.x < otherObject.transform.position.x)
                {
                    damageScript.koopaShellMoving = true;
                    movementScript.moveRight = true;
                    damageScript.audioSource.volume = 0.5f;
                    damageScript.audioSource.PlayOneShot(damageScript.shellKickAudio);
                }

        
            }



        }

        if (playerHealth == 0)
        {
            if(!pmanager.marioDead)
            {
                Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>(), collision.collider, true);
                thisAnim.SetBool("dead", true);               
                pmanager.marioDead = true;
                gameManager.OnMarioDeath();
                
            }
            
            
        }
    }//End of onCollision




}
