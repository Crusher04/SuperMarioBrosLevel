using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    private Rigidbody2D rb;
    private Vector3 localScale;

    public bool moveRight;

    public bool isKoopa;
    public bool isGoomba;
    public bool isPiranha;



    // Start is called before the first frame update
    void Start()
    {

        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isKoopa || isGoomba)
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

    }


    void OnTriggerEnter2D(Collider2D trigger)
    {

        if (isKoopa || isGoomba)
        {
            if (trigger.gameObject.CompareTag("Switch"))
            {
                if (moveRight)
                {
                    localScale.x *= -1;
                    transform.localScale = localScale;
                    moveRight = false;
                }
                else
                {
                    localScale.x *= -1;
                    transform.localScale = localScale;
                    moveRight = true;

                }
            }
        }

    }

}
