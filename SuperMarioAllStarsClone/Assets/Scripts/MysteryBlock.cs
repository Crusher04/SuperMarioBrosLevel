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

    [Header("Mystery Prize GameObjects")]
    public GameObject CoinGameObject;
    public GameObject MushroomGameObject;
    public GameObject LifeGameObject;
    public GameObject SuperLeafGameObject;

    [Header("Animation Spawn Location")]
    public Transform AnimSpawnLocation;

    [Header("Animation Event Handler Game Object")]
    public MBAnimEventHandler AnimEventHandler;

    [Header("Audio Sources")]
    private AudioSource myAudio;
    public AudioClip blockHitAudio;
    public AudioClip CoinAudio;
    public AudioClip MushroomAudio;
    public AudioClip LifeAudio;
    public AudioClip SuperLeafAudio;

    [Header("Bottom Checker")]
    [SerializeField] private Transform BottomOfBlock;

    [Header("Public Variables")]
    public bool isBlockHit = false;

    

    private GameObject PlayerObject;
    private Rigidbody2D PlayerRB;

    private Animator anim;
    private Rigidbody2D rb;

    private float timer = 0;

    //Check if items are spawned
    private bool isMushroomSpawned = false;

    //Play audio once if in update
    private bool audioIsPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
        PlayerRB = PlayerObject.GetComponent<Rigidbody2D>();
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isBlockHit && spawnMushroom && !isMushroomSpawned && AnimEventHandler.MushroomAnimComplete)
        {
            Vector3 newPos = transform.position;
            newPos.y += 1;

            isMushroomSpawned = true;
            GameObject Mushroom = (GameObject)Instantiate(MushroomGameObject, newPos, transform.rotation);
        }

        if(!myAudio.isPlaying && isBlockHit && !isMushroomSpawned && !audioIsPlaying) 
        {
            myAudio.clip = MushroomAudio;
            myAudio.Play();
            audioIsPlaying = true;

            if (isMushroomSpawned)
                audioIsPlaying = false;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!myAudio.isPlaying)
        {
            myAudio.clip = blockHitAudio;
        }

        if (PlayerObject.transform.position.y <= BottomOfBlock.transform.position.y && PlayerRB.velocity.y >= 0 && collision.gameObject.tag == "Player") 
        {
            myAudio.clip = blockHitAudio;
            anim.SetBool("blockHit", true);
            myAudio.Play();

        }

        




    }

    public void blockHitAnimComplete()
    {
        isBlockHit = true;
    }
    
}
