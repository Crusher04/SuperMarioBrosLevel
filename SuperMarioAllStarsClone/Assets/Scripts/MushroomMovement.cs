using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMovement : MonoBehaviour
{
    [Header("Mushroom Speed")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float Yspeed = 2f;

    [Header("Ground Check Componenets")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Mystery Block & Components")]
    public MysteryBlock mysteryBlock;
    public BoxCollider2D BoxColl;
    public BoxCollider2D Trigger;

    private bool hasMushroomRisen = false;
    private bool mushroomCanRoam = false;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsGrounded())
             rb.velocity = new Vector3(speed, 0, 0);
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
    }
}
