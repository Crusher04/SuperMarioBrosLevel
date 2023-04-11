using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{

    [SerializeField]
    public GameObject Enemy;

    public bool enemyDeath;

    [SerializeField]
    public AnimationClip enemyDeathClip;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        enemyDeath = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (enemyDeath == true)
        {
            animator.Play(enemyDeathClip.name);
            Destroy(Enemy, 1.0f);
        }

        
    }








}
