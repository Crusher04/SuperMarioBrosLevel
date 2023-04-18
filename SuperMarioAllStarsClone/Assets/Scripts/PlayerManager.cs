using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Mario Animators & Triggers")]
    public AnimatorController marioSmallAnimator;
    public AnimatorController marioBigAnimator;
    public bool marioSmall = false;
    public bool marioBig = false;

    [Header("Mario Sprites")]
    public Sprite marioSmallSprite;
    public Sprite marioBigSprite;   

    private bool mapMarioSmall = false;
    private bool mapMarioBig = false;

    [Header("Player Child Object")]
    public GameObject playerObject;

    private void Awake()
    {
        DontDestroyOnLoad(this);
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


        }
    }
}
