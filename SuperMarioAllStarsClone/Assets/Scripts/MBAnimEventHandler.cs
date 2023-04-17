using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MBAnimEventHandler : MonoBehaviour
{
    [Header("Animation Event Flags")]
    public bool MushroomAnimComplete = false;
    public bool CoinAnimComplete = false;
    public bool LifeAnimComplete = false;
    public bool SuperLeafAnimComplete = false;
    
    [Header("Animator / Myster Block Parent")]
    public Animator anim;

    public MysteryBlock m_Block;

    [Header("Watched Variables")]
    public bool blockHit = false;

    private void Start()
    {

    }

    void Update()
    {
        blockHit = m_Block.isBlockHit;

        if (m_Block.isBlockHit && !MushroomAnimComplete)
        {
            anim.SetBool("spawnMushroom", true);
        }
        else
        {
            anim.SetBool("spawnMushroom", false);
        }
    }


    public void MushroomAnimIsCompleted()
    {
        MushroomAnimComplete = true;
    }

    public void CoinAnimIsComplete()
    {
        CoinAnimComplete = true;
    }

    public void LifeAnimIsComplete()
    {
        LifeAnimComplete = true;
    }

    public void SuperLeafAnimIsComplete()
    {
        SuperLeafAnimComplete = true;
    }
}
