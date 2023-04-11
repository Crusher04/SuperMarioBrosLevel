using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerEnemyCollision : MonoBehaviour
{

    [SerializeField]
    public GameObject enemy;
    private EnemyTakeDamage script;

    private int playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        script = enemy.GetComponent<EnemyTakeDamage>();
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


    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check to see if the enemy collided with a switch object
        if (collision.gameObject.CompareTag("Enemy"))
        {




            if (collision.gameObject.GetComponent<BoxCollider2D>())
            {

                playerHealth -= 1;

            }

            if (collision.gameObject.GetComponent<EdgeCollider2D>())
            {
                script.enemyDeath = true;
            }
        }

    }




}
