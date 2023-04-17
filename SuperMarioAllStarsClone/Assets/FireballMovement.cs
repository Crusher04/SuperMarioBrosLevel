using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class FireballMovement : MonoBehaviour
{

    private GameObject instantiator;
    private Rigidbody2D rb;

    private int hSpeed;
    private int vSpeed;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        hSpeed = 4;
        vSpeed = 2;


    }

    // Update is called once per frame
    void Update()
    {
        if (instantiator.GetComponent<PiranhaClass>().piranhaLookingRight && instantiator.GetComponent<PiranhaClass>().piranhaLookingUp)
        {

            rb.velocity = new Vector2(hSpeed, vSpeed);

        }

        if (!instantiator.GetComponent<PiranhaClass>().piranhaLookingRight && !instantiator.GetComponent<PiranhaClass>().piranhaLookingUp)
        {

            rb.velocity = new Vector2(-hSpeed, -vSpeed);

        }

        if (!instantiator.GetComponent<PiranhaClass>().piranhaLookingRight && instantiator.GetComponent<PiranhaClass>().piranhaLookingUp)
        {

            rb.velocity = new Vector2(-hSpeed, vSpeed);

        }

        if (instantiator.GetComponent<PiranhaClass>().piranhaLookingRight && !instantiator.GetComponent<PiranhaClass>().piranhaLookingUp)
        {

            rb.velocity = new Vector2(hSpeed, -vSpeed);

        }
        Destroy(gameObject, 10.0f);
    }

    public void SetInstantiator(GameObject instantiator)
    {
        this.instantiator = instantiator;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {


        Destroy(gameObject);


    }
}
