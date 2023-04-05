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

    public AudioClip blockHitAudio;
    public AudioClip CoinAudio;
    public AudioClip MushroomAudio;
    public AudioClip LifeAudio;
    public AudioClip SuperLeafAudio;

    private Animator anim;
    private Rigidbody2D rb;
    private float timer = 0;
    private bool playHitOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!playHitOnce)
        {
            playHitOnce = true;
            GetComponent<AudioSource>().clip = blockHitAudio;
            GetComponent<AudioSource>().Play();
        }

        anim.SetBool("blockHit", true);
       
    }

    
}
