using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Mario In-Game Animators & Triggers")]
    public AnimatorController marioSmallAnimator;
    public AnimatorController marioBigAnimator;
    public AnimatorController marioDeathAnimator;

    public bool marioSmall = false;
    public bool marioBig = false;
    public bool marioDead = false;

    [Header("Mario Sprites")]
    public Sprite marioSmallSprite;
    public Sprite marioBigSprite;


    [Header("Mario Map Animators & Sprites")]
    public AnimatorController marioMapSmallAnimator;
    public AnimatorController marioMapBigAnimator;
    public Sprite marioMapSmallSprite;
    public Sprite marioMapBigSprite;

    private bool mapMarioSmall = false;
    private bool mapMarioBig = false;

    [Header("Player Child Object")]
    public GameObject playerObject;


    [Header("Audio Clips")]
    public AudioClip playerShrinks;
    public AudioClip playerGrows;
    public AudioSource myAudio;
    public bool audioFlag = false;

    [Header("Game Manager")]
    public GameManager gameManager;

    private void Awake()
    {
        
        //DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(marioBig)
        {
            marioSmall = false;
            mapMarioSmall = false;
            mapMarioBig = true;
            playerObject.GetComponent<Animator>().runtimeAnimatorController = marioBigAnimator;
            playerObject.GetComponent<SpriteRenderer>().sprite = marioBigSprite;

            Vector2 spriteSize = playerObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
            playerObject.GetComponent<BoxCollider2D>().size = spriteSize;

            if(audioFlag)
            {
                myAudio.clip = playerGrows;
                myAudio.Play();
                audioFlag = false;
            }
            



        }
        else
        {         
                marioSmall = true;
                mapMarioSmall = true;
                mapMarioBig = false;
                playerObject.GetComponent<Animator>().runtimeAnimatorController = marioSmallAnimator;
                playerObject.GetComponent<SpriteRenderer>().sprite = marioSmallSprite;

                Vector2 spriteSize = playerObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
                playerObject.GetComponent<BoxCollider2D>().size = spriteSize;

                if (audioFlag)
                {
                    myAudio.clip = playerShrinks;
                    myAudio.Play();
                    audioFlag = false;
                }
            
        }

        if (marioDead)
        {
            playerObject.GetComponent<Animator>().runtimeAnimatorController = marioDeathAnimator;
            gameManager.GetComponent<AudioSource>().Stop();
            gameManager.GetComponent<AudioSource>().clip = gameManager.playerDeath;
            gameManager.GetComponent<AudioSource>().Play();
            gameManager.OnMarioDeath();
        }

    }//End of update

}
