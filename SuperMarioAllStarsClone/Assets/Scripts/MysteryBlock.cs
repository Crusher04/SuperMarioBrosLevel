using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MysteryBlock : MonoBehaviour
{
    [Header("Mystery Prize")]
    public bool spawnCoin = false;
    public bool spawnMushroom = false;
    public bool spawnLife = false;
    public bool spawnSuperLeaf = false;

    [Header("Mystery Prize Components")]
    public GameObject CoinComponent;
    public GameObject MushroomComponent;
    public GameObject LifeComponent;
    public GameObject SuperLeafComponent;

    [Header("Audio Sources")]
    public AudioClip blockHitAudio;
    public AudioClip CoinAudio;
    public AudioClip MushroomAudio;
    public AudioClip LifeAudio;
    public AudioClip SuperLeafAudio;

    [Header("Bottom Checker")]
    [SerializeField] private Transform BottomOfBlock;

    private GameObject PlayerObject;
    private Rigidbody2D PlayerRB;

    private Animator anim;
    private Rigidbody2D rb;

    private float timer = 0;
    
    //Audio Bools
    public bool isBlockHit = false;

    //Check if items are spawned
    private bool isMushroomSpawend = false;


    public Transform spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        PlayerRB = PlayerObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isBlockHit && spawnMushroom && !isMushroomSpawend)
        {
            Vector3 newPos = transform.position;
            newPos.y += 1;

            isMushroomSpawend = true;
            GameObject Mushroom = (GameObject)Instantiate(MushroomComponent, newPos, transform.rotation);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Default block hit noise if mystery prize is already spawned
        if (isBlockHit && collision.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().clip = blockHitAudio;            
        }

        if (PlayerObject.transform.position.y <= BottomOfBlock.transform.position.y && PlayerRB.velocity.y >= 0 && collision.gameObject.tag == "Player") 
        {
            isBlockHit = true;
            anim.SetBool("blockHit", true);
            GetComponent<AudioSource>().Play();
        }

        

    }

    
}
