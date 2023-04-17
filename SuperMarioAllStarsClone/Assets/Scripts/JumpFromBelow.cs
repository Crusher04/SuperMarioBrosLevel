using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class JumpFromBelow : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private GameObject PlayerObject;

    [Header("EdgeCollider Platforms")]
    [SerializeField] private Transform platformLayerOne;
    [SerializeField] private Transform platformLayerTwo;
    [SerializeField] private Transform platformLayerThree;
    [SerializeField] private Transform platformLayerFour;

    [Header("EdgeColliders")]
    [SerializeField] private EdgeCollider2D edgeCollider2DOne;
    [SerializeField] private EdgeCollider2D edgeCollider2DTwo;
    [SerializeField] private EdgeCollider2D edgeCollider2DThree;
    [SerializeField] private EdgeCollider2D edgeCollider2DFour;

    [Header("Platform Materials")]
    [SerializeField] private PhysicsMaterial2D Slippery;
    [SerializeField] private PhysicsMaterial2D Rough;

    private bool inPlatformBox = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        IsPlayerBelow();
        if (!inPlatformBox)
            PlayerObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void IsPlayerBelow()
    {
        if (PlayerObject.transform.position.y  < platformLayerOne.position.y && platformLayerOne != null)
        {
            //edgeCollider2DOne.isTrigger = true;
            if (PlayerObject.GetComponent<Rigidbody2D>().velocity.y > 0)
                Physics2D.IgnoreCollision(PlayerObject.GetComponent<BoxCollider2D>(), edgeCollider2DOne, true);
            
        }
        else
            Physics2D.IgnoreCollision(PlayerObject.GetComponent<BoxCollider2D>(), edgeCollider2DOne, false);


        if (PlayerObject.transform.position.y < platformLayerTwo.position.y && platformLayerTwo != null)
        {
            if (PlayerObject.GetComponent<Rigidbody2D>().velocity.y > 0)
                Physics2D.IgnoreCollision(PlayerObject.GetComponent<BoxCollider2D>(), edgeCollider2DTwo, true);
        }
        else
            Physics2D.IgnoreCollision(PlayerObject.GetComponent<BoxCollider2D>(), edgeCollider2DTwo, false);

        if (PlayerObject.transform.position.y < platformLayerThree.position.y && platformLayerThree != null)
        {
            if (PlayerObject.GetComponent<Rigidbody2D>().velocity.y > 0)
                Physics2D.IgnoreCollision(PlayerObject.GetComponent<BoxCollider2D>(), edgeCollider2DThree, true);
        }
        else
            Physics2D.IgnoreCollision(PlayerObject.GetComponent<BoxCollider2D>(), edgeCollider2DThree, false);

        if (PlayerObject.transform.position.y < platformLayerFour.position.y && platformLayerFour != null)
        {
            if (PlayerObject.GetComponent<Rigidbody2D>().velocity.y > 0)
                Physics2D.IgnoreCollision(PlayerObject.GetComponent<BoxCollider2D>(), edgeCollider2DFour, true);
        }
        else
            Physics2D.IgnoreCollision(PlayerObject.GetComponent<BoxCollider2D>(), edgeCollider2DFour, false);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("PLAYER IN BOX");
            inPlatformBox = true;
        }
        else
        {
            inPlatformBox = false;
        }
    }
}
