using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MysteryBlock : MonoBehaviour
{

    public bool spawnCoin = false;
    public bool spawnMushroom = false;
    public bool spawnLife = false;
    public bool spawnSuperLeaf = false;

    public GameObject Coin;
    public GameObject Mushroom;
    public GameObject Life;
    public GameObject SuperLeaf;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Coin Block Collision OK");
    }
}
