using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMovement : MonoBehaviour
{
    [Header("Mushroom Speed")]
    [SerializeField] private float speed = 2f;
   

    [Header("Ground Check Componenets")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Mystery Block & Components")]
    public MysteryBlock mysteryBlock;
    public BoxCollider2D BoxColl;
    public BoxCollider2D Trigger;
    private Rigidbody2D rb;
    private GameObject player;

    private bool firstSpawn = true;
    private int orientation = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(IsGrounded())
        {
            if (firstSpawn)
            {
                if(player.transform.position.x >= transform.position.x)
                {
                    orientation = -1;
                }
                else
                {
                    orientation = 1;
                }
            }

            rb.velocity = new Vector3(speed * orientation, 0, 0);
        }
             
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Mystery Block")
        {
            mysteryBlock = collision.gameObject.GetComponent<MysteryBlock>();
        }

        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            player.GetComponentInParent<PlayerManager>().marioBig = true;
        }

        if(collision.gameObject.tag == "Pipe")
        {
            Debug.Log("PIPE COLLISION WITH MUSHROOM");
            orientation = -1;
        }

        if(collision.gameObject.tag == "InvisWall")
        {
            Destroy(this.gameObject);
        }
    }


}
