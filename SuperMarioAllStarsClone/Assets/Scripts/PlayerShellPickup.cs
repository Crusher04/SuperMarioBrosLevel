using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerShellPickup : MonoBehaviour
{

    public int shellPickup;

    // Start is called before the first frame update
    void Start()
    {
        shellPickup = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(shellPickup);
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            shellPickup = 1;
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            shellPickup = 2;
        }

        


    }
}
