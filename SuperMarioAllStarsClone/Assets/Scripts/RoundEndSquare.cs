using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEndSquare : MonoBehaviour
{
    public GameObject star;
    public GameObject flower;
    public GameObject mushroom;
    bool trigger = false;
    bool loop = true;
    // Start is called before the first frame update
    void Start()
    {
        if (!trigger)
            StartCoroutine(Spin());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (loop)
            StartCoroutine(Spin());
    }

    IEnumerator Spin()
    {
        loop = false;

        if(!trigger)
            star.SetActive(true);
        yield return new WaitForSeconds(1f);

        if (!trigger)
        {
            star.SetActive(false);
            mushroom.SetActive(true);
        }
        
        yield return new WaitForSeconds(1f);

        if (!trigger)
        {
            mushroom.SetActive(false);
            flower.SetActive(true);
        }

        yield return new WaitForSeconds(1f);
        if(!trigger)
            flower.SetActive(false);
        loop = true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopCoroutine(Spin());
        trigger = true;
        loop = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StopCoroutine(Spin());  
        trigger = true;
        loop = false;
    }
}
