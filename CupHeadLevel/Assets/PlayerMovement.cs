using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 7f;
    private Rigidbody2D rb;
    float moveX;
    private bool isJumping = false;



    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {

        moveX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {

            rb.velocity = new Vector2(rb.velocity.x, 14);
            isJumping = true;
        }
        
        if (rb.velocity.y == 0)
        {

            isJumping = false;

        }

    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }


}
