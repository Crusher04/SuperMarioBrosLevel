using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Music")]
    public AudioSource mapScreen;
    public AudioSource levelOne;
    public AudioSource levelOneHurry;
    public AudioSource levelEnter;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        
    }


    
}
