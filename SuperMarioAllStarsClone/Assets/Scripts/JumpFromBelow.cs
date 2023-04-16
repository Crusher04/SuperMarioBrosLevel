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

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        IsPlayerBelow();
    }

    private void IsPlayerBelow()
    {
        if (PlayerObject.transform.position.y < platformLayerOne.position.y && platformLayerOne != null)
        {
            edgeCollider2DOne.isTrigger = true;
        }
        else
            edgeCollider2DOne.isTrigger = false;


        if (PlayerObject.transform.position.y < platformLayerTwo.position.y && platformLayerTwo != null)
        {
            edgeCollider2DTwo.isTrigger = true;
        }
        else
            edgeCollider2DTwo.isTrigger = false;

        if (PlayerObject.transform.position.y < platformLayerThree.position.y && platformLayerThree != null)
        {
            edgeCollider2DThree.isTrigger = true;
        }
        else
            edgeCollider2DThree.isTrigger = false;

        if (PlayerObject.transform.position.y < platformLayerFour.position.y && platformLayerFour != null)
        {
            edgeCollider2DFour.isTrigger = true;
        }
        else
            edgeCollider2DFour.isTrigger = false;

    }
}
