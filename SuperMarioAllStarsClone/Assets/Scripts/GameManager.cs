using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Music")]
    public AudioSource mapScreenAS;
    public AudioSource levelOneAS;
    public AudioSource levelOneHurryAS;
    public AudioSource levelEnterAS;

    public bool mapEnabled = true;
    public bool levelOneEnabled = false;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        
    }


    
}
