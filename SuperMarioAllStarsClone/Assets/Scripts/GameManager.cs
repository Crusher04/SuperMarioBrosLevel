using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Music")]
    //public AudioSource mapScreenAS;
    public  AudioClip levelOneMusic;
    public  AudioClip levelOneHurryMusic;
    public  AudioClip courseClear;
    public  AudioSource LevelMusic;

    [Header("Audio Cues")]
    public AudioClip playerDeath;
    public AudioClip gameOver;

    [Header("Player Obejct")]
    public GameObject Player;
    public GameObject DeathPointOne;
    public GameObject DeathPointTwo;
    public Vector3 moveTowardsDeathPointOne;
    public Vector3 moveTowardsDeathPointTwo;
    bool flipDeathPos = false;

    [Header("Watched Variables")]
    public bool mapEnabled = true;
    public bool levelOneEnabled = false;
    public bool marioDead = false;

    public static int totalCoins;
    public static int totalLives;

    [Header("GameObjects")]
    public GameObject Goomba1;
    public GameObject Goomba2;
    public GameObject Goomba3;
    public GameObject Goomba4;
    public GameObject WingedGoomba;
    public GameObject Piranha;
    public GameObject RedKoopa1;
    public GameObject RedKoopa2;
    public GameObject RedKoopa3;
    public GameObject WingedKoopa1;
    public GameObject WingedKoopa2;
    public GameObject WingedKoopa3;


    bool deathAnim = false;

    void Awake()
    {
        Instance = this;
        //DontDestroyOnLoad(this);
    }

    private void Start()
    {
        LevelMusic.clip = levelOneMusic;
        LevelMusic.Play();
        if (totalLives == 0)
            totalLives = 5;

        Player.GetComponent<PlayerInput>().enabled = true;

        //Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
        if(deathAnim)
        {
            StartCoroutine(DeathMoveDelay());
            

        }
    }

    public void ResetTheGame()
    {
       
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void UpdateCoins(int numOfCoins)
    {
        if (numOfCoins != totalCoins)
        {
            totalCoins = numOfCoins;
        }
    }

    public int GetAmountOfCoins()
    {
        return totalCoins;
    }

    public void UpdateLives(int numOfLives)
    {
        if (numOfLives != totalLives)
        {
            totalLives = numOfLives;
        }
    }

    public int GetAmountOfLives()
    {
        return totalLives;
    }

    public void OnMarioDeath()
    {     
        Player.GetComponent<PlayerInput>().enabled = false;
        Goomba1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        Goomba2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        Goomba3.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        Goomba4.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        RedKoopa1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        RedKoopa2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        RedKoopa3.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        WingedGoomba.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        Piranha.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        WingedKoopa1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        WingedKoopa2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        WingedKoopa3.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        totalLives -= 1;
        deathAnim = true;

        moveTowardsDeathPointOne = Player.GetComponentInParent<Transform>().position;
        moveTowardsDeathPointOne.y += 3;
        moveTowardsDeathPointTwo = Player.GetComponentInParent<Transform>().position;
        moveTowardsDeathPointTwo.y -= 20;
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(1);     
    }

    IEnumerator DeathMoveDelay()
    {
        yield return new WaitForSeconds(1.2f);
        Player.GetComponent<BoxCollider2D>().isTrigger = true;
        
        if (Player.transform.position.y >= DeathPointOne.transform.position.y)
        {
            flipDeathPos = true;
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, moveTowardsDeathPointTwo, 0.05f);

        }

        if (!flipDeathPos)
        {
            Player.transform.position = Vector3.MoveTowards(Player.transform.position, moveTowardsDeathPointTwo, 0.05f);
            yield return new WaitForSeconds(0.2f);
        }

        if(Player.transform.position.y < -20)
        {
            ResetTheGame();
        }
        
    }
}