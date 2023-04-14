using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerEnemyCollision : MonoBehaviour
{
    ///Initialize Variables


    //Variables for Player
    private int playerHealth;
    private bool playerHit;

    // Start is called before the first frame update
    void Start()
    {

        playerHealth = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth == 0)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene

        }
    }

    //Collision for player
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check to see if the enemy collided with a switch object
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

            // Get the script component of the collided object
            EnemyTakeDamage script = collision.gameObject.GetComponent<EnemyTakeDamage>();

            //Check to see IF the player collides with the side of an enemy
            if (contactPos.y < otherObject.transform.position.y) 
            {
                //Decrease player health and set playerHit to true
                playerHealth -= 1;
                playerHit = true;
            }

            //IF playerHit equals false then check to see if the player collides with the top of an enemy
            if (playerHit == false)
            {
                if (contactPos.x < otherObject.transform.position.x)
                {
                    //Set the enemy's enemyDamage bool to true
                    script.enemyDamage = true;

                }
            }

        }

    }




}
