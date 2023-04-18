using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiranhaClass : MonoBehaviour
{

    [SerializeField]
    public AnimationClip piranhaDownClip;

    [SerializeField]
    public AnimationClip piranhaUpClip;


    private Rigidbody2D rb;
    private Animator animator;
    private EnemyMovement movementScript;
    public Transform playerTransform;
    public Transform enemyTransform;
    private Vector3 localScale;

    private float timeLimit;
    private float timeLeft;
    public float time;
    public float waitTime;
    private float piranhaHeightPlus;
    private float piranhaHeightMinus;

    public GameObject fireball;
    public bool fireballActive;
    private GameObject fireballSpawned;

    public bool piranhaLookingRight;
    public bool piranhaLookingUp;

    private Vector2 spawnLocation;
    private Vector2 newSpawnLocation;

    public bool isFirePiranha;
    private int fireBallSpawnedAmount;

    [SerializeField]
    public AudioClip fireballAudio;

    public AudioSource audioSource;
    public bool usingAudio;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        movementScript = GetComponent<EnemyMovement>();
        audioSource = GetComponent<AudioSource>();

        timeLimit = time;
        timeLeft = timeLimit;
        piranhaHeightPlus = 1000;
        piranhaHeightMinus = -1000;

        spawnLocation = rb.position;
        spawnLocation.y += 2;
        newSpawnLocation = spawnLocation;
        fireBallSpawnedAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (fireballActive)
        {
            if (fireBallSpawnedAmount == 0)
            {
                fireballSpawned = GameObject.Instantiate(fireball, newSpawnLocation, Quaternion.identity);
                fireballSpawned.GetComponent<FireballMovement>().SetInstantiator(gameObject);
                //GameObject fireballObject = Instantiate(fireball, rb.position, Quaternion.identity);
                fireBallSpawnedAmount = 1;
                if (usingAudio)
                {
                    audioSource.PlayOneShot(fireballAudio);
                }
                fireballActive = false;
            }
        }

        timeLeft -= Time.deltaTime;

        if (movementScript.isPiranha)
        {

            Vector2 toPlayer = playerTransform.position - enemyTransform.position;
            Vector2 enemyRight = enemyTransform.right;
            // Calculate dot product between toPlayer and enemyRight
            float dotProduct = Vector2.Dot(toPlayer, enemyRight);
            if (timeLeft >= 0)
            {
                newSpawnLocation = spawnLocation;
                rb.velocity = new Vector2(0, 2);
                if (rb.position.y >= piranhaHeightPlus)
                {
                    rb.position = new Vector2(rb.position.x, piranhaHeightPlus);

                }
                
                if (dotProduct > 0)
                {
                    
                    localScale.x = -1;
                    transform.localScale = localScale;
                    piranhaLookingRight = true;
                    newSpawnLocation = new Vector2(newSpawnLocation.x + 1, newSpawnLocation.y);
                }
                if (dotProduct < 0)
                {
                    
                    localScale.x = 1;
                    transform.localScale = localScale;
                    piranhaLookingRight = false;
                    newSpawnLocation = new Vector2(newSpawnLocation.x - 1, newSpawnLocation.y);
                }

                if (playerTransform.position.y > enemyTransform.position.y)
                {
                    animator.Play(piranhaUpClip.name);
                    piranhaLookingUp = true;
                    newSpawnLocation = new Vector2(newSpawnLocation.x, newSpawnLocation.y + 3);
                }

                if (playerTransform.position.y < enemyTransform.position.y)
                {
                    animator.Play(piranhaDownClip.name);
                    piranhaLookingUp = false;
                    newSpawnLocation = new Vector2(newSpawnLocation.x, newSpawnLocation.y + 1);
                }

                
            }

            if (timeLeft <= 0f && timeLeft >= -waitTime)
            {
                newSpawnLocation = spawnLocation;
                if (dotProduct > 0)
                {

                    localScale.x = -1;
                    transform.localScale = localScale;
                    
                    newSpawnLocation = new Vector2(newSpawnLocation.x + 1, newSpawnLocation.y);

                }
                if (dotProduct < 0)
                {

                    localScale.x = 1;
                    transform.localScale = localScale;
                    
                    newSpawnLocation = new Vector2(newSpawnLocation.x - 1, newSpawnLocation.y);
                }

                if (rb.position.y >= piranhaHeightPlus)
                {
                    rb.position = new Vector2(rb.position.x, piranhaHeightPlus);

                }

                if (playerTransform.position.y > enemyTransform.position.y)
                {
                    animator.Play(piranhaUpClip.name);
                    
                    newSpawnLocation = new Vector2(newSpawnLocation.x, newSpawnLocation.y + 1);
                }

                if (playerTransform.position.y < enemyTransform.position.y)
                {
                    animator.Play(piranhaDownClip.name);
                    
                    newSpawnLocation = new Vector2(newSpawnLocation.x, newSpawnLocation.y + 1);
                }
                piranhaHeightPlus = rb.position.y;
                rb.velocity = new Vector2(0, 0);

            }

            if (isFirePiranha)
            {
                if (timeLeft >= -1.00f && timeLeft <= -0.7500f)
                {
                    fireballActive = true;
                }
            }

            if (timeLeft <= -waitTime && timeLeft >= -time * 2)
            {
                
                rb.velocity = new Vector2(0, -2);
                if (rb.position.y <= piranhaHeightMinus)
                {

                    rb.position = new Vector2(rb.position.x, piranhaHeightMinus);

                }
            }

            if (timeLeft <= -time * 2)
            {
                
                if (rb.position.y <= piranhaHeightMinus)
                {

                    rb.position = new Vector2(rb.position.x, piranhaHeightMinus);

                }
               
                piranhaHeightMinus = rb.position.y;
                rb.velocity = new Vector2(0, 0);

            }

            if (timeLeft <= -waitTime * 3)
            {
                fireballActive = false;
                fireBallSpawnedAmount = 0;
                timeLeft = time;

            }
        }

    }








}
