using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float moveSpeed = 5f;
    private Rigidbody2D rb;


    public bool moveRight;

    // Start is called before the first frame update
    void Start()
    {


        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (moveRight)
        {

            rb.velocity = new Vector2(moveSpeed, 0);

        }
        else
        {

            rb.velocity = new Vector2(-moveSpeed, 0);

        }

    }


    void OnTriggerEnter2D(Collider2D trigger)
    {

        if (trigger.gameObject.CompareTag("Switch"))
        {
            if (moveRight)
            {

                moveRight = false;

            }
            else
            {

                moveRight = true;

            }
        }

    }

}
