using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    ///Initialize Variables

    //Initialize global Variables
    [SerializeField]
    public GameObject enemy;
    

    [SerializeField]
    public AnimationClip enemyDamageClip;

    //Enemy Variables
    public bool enemyDamage;
    private bool koopaShell;
    private bool koopaShellMoving;
    private int koopaShellHit;

    //Initialize component variables
    private EnemyMovement script;
    private Animator animator;
    private Transform transform;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        enemyDamage = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        script = enemy.GetComponent<EnemyMovement>();
        koopaShellHit = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Check to see IF the enemy has been damaged
        if (enemyDamage == true)
        {
            //Call the change sprite function
            ChangeSprite();

            //Check to see if the enemy is a goomba
            if(script.isGoomba)
            { 
                Destroy(gameObject, 1.0f);
            }

            //Check too see if the enemy is a koopa
            if(script.isKoopa)
            {
                //Increaase koopaShellHit by 1
                koopaShellHit += 1;
               
                //IF koopaShellHit is 2 then set koopaShellMoving to false and koopaShell to false
                if (koopaShellHit == 2)
                {
                    koopaShellMoving = false;
                    koopaShell = false;

                }

                //IF koopaShell is false set koopaShellHit to 0
                if(koopaShell == false)
                {

                    koopaShellHit = 0;
                }

                //Set koopaShell to true
                koopaShell = true;
                
                
                //IF koopaShellHit is 0 then call change sprite function
                if (koopaShellHit == 0)
                {
                    ChangeSprite();
                }
                //IF koopaShellHit is 1 then set koopaShellMoving to true
                if (koopaShellHit == 1)
                {

                    koopaShellMoving = true;

                }

                //Set enemyDamage back to false
                enemyDamage = false;

            }
        }


        //IF koopaShellMoving is true then change the velocity for the shell
        if (koopaShellMoving == true)
        {
            rb.velocity = new Vector2(15, -5);
        }


        
    }

    //Change sprite function
    void ChangeSprite()
    {
        //Play enemy damage clip
        animator.Play(enemyDamageClip.name);
        //Set enemyTookDamage to true
        script.enemyTookDamage = true;
        //Change scale of sprite
        transform.localScale = new Vector2(1.0f, 0.75f);

    }






}
