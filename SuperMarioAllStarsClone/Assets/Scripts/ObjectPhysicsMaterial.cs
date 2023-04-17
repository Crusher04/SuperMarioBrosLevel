using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPhysicsMaterial : MonoBehaviour
{
    //Physics Material
    [Header("Physics2D Materials")]
    [SerializeField] private PhysicsMaterial2D Slippery;
    [SerializeField] private PhysicsMaterial2D Rough;

    [Header("Player Object Checker")]
    [SerializeField] private Transform TopOfBlock;
    [SerializeField] private BoxCollider2D BoxColliderOfChoice;

    private GameObject PlayerObject;


    // Start is called before the first frame update
    void Start()
    {   
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMaterial();
    }

    private void ChangeMaterial()
    {
        if (BoxColliderOfChoice == null)
        {
            BoxColliderOfChoice = this.GetComponent<BoxCollider2D>();
        }
        

        if (PlayerObject.transform.position.y < TopOfBlock.transform.position.y)
        {
            BoxColliderOfChoice.GetComponent<BoxCollider2D>().sharedMaterial = Slippery;
        }
        else
            BoxColliderOfChoice.GetComponent<BoxCollider2D>().sharedMaterial = Rough;
    }
}
