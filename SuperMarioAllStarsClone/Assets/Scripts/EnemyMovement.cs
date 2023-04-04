using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private bool collided = false;
    private Collision coll;



    // Start is called before the first frame update
    void Start()
    {


        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collision>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        OnCollisionEnter(coll);


    }
    
    void OnCollisionEnter(Collision collision)
    {

        if (!collided)
        {
            //Check for a match with the specific tag on any GameObject that collides with your GameObject
            if (collision.gameObject.tag == "Switch")
            {
             
                moveSpeed *= -5;
                collided = true;
            }
        }
    }



}
