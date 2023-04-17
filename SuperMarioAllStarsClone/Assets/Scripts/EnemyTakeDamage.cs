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
    public AnimationClip DeathClip;

    [SerializeField]
    public AnimationClip ShellClip;

    [SerializeField]
    public AnimationClip MovementClip;

    //Enemy Variables
    public bool enemyDamage;
    private bool koopaShell;
    public bool koopaShellMoving;
    public int koopaShellHit;
    public bool enemyDeath;
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
        koopaShellHit = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //Check to see IF the enemy has been damaged
        if (enemyDamage == true)
        {


            //Check to see if the enemy is a goomba
            if(script.isGoomba)
            {
                if (!script.hasWings)
                {
                    //Call the change sprite function
                    animator.Play(DeathClip.name);
                    script.enemyTookDamage = true;
                    //rb.velocity = new Vector2(rb.position.x, rb.velocity.y - 10);
                    enemyDeath = true;
                    Destroy(gameObject, 1.0f);
                    enemyDamage = false;
                    
                }
                if (script.hasWings)
                {
                    //Call the change sprite function
                    animator.Play(MovementClip.name);
                    rb.velocity = new Vector2(rb.position.x, rb.velocity.y - 10);
                    script.enemyTookDamage = true;
                    script.hasWings = false;
                    script.enemyTookDamage = false;
                    enemyDamage = false;
                    
                }
            }

            //Check too see if the enemy is a koopa
            if(script.isKoopa)
            {
                if (!script.hasWings)
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
                    if (koopaShell == false)
                    {

                        koopaShellHit = 0;
                    }

                    //Set koopaShell to true
                    koopaShell = true;


                    //IF koopaShellHit is 0 then call change sprite function
                    if (koopaShellHit == 0)
                    {
                        animator.Play(DeathClip.name);
                        transform.localScale = new Vector2(1.0f, 0.75f);
                        script.enemyTookDamage = true;
                    }
                    //IF koopaShellHit is 1 then set koopaShellMoving to true
                    if (koopaShellHit == 1)
                    {

                        koopaShellMoving = true;

                    }

                    //Set enemyDamage back to false
                    enemyDamage = false;
                }
                if (script.hasWings)
                {
                    animator.Play(MovementClip.name);
                    rb.velocity = new Vector2(rb.position.x, rb.velocity.y - 2);
                    script.enemyTookDamage = false;
                    
                    script.hasWings = false;

                }
                enemyDamage = false;

            }
        }

        if (koopaShellHit == 0)
        {

            transform.localScale = new Vector2(1.0f, 0.75f);

        }

        //IF koopaShellMoving is true then change the velocity for the shell
        if (koopaShellMoving == true)
        {
            koopaShellHit = 1;
            animator.Play(ShellClip.name);
            script.enemyTookDamage = false;
            script.moveSpeed = 10;
            transform.localScale = new Vector2(1.0f, 0.75f);
            if (rb.velocity.y > 0.0f)
            {
                // If the object is moving up, stop it
                rb.velocity = new Vector2(rb.velocity.x, 0.0f);
            }
        }


        
    }

}
