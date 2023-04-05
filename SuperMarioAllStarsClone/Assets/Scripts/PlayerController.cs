using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator anim;

    public float moveSpeed = 1.0f;

    public Vector2 oldPos = Vector2.zero;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        oldPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);

        if(oldPos.x < transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("moving", true);
        }
        else if (oldPos.x > transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
            
        }

    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        oldPos = transform.position;
    }
}
