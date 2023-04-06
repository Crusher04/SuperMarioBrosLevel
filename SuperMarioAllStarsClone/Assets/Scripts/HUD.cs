using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HUD : MonoBehaviour
{

    public GameObject Mario;
    public GameObject Luigi;
    public GameObject zeroH, oneH, twoH, threeH, fourH, fiveH, sixH, sevenH, eightH, nineH;
    public GameObject zeroT, oneT, twoT, threeT, fourT, fiveT, sixT, sevenT, eightT, nineT;
    public GameObject zeroO, oneO, twoO, threeO, fourO, fiveO, sixO, sevenO, eightO, nineO;

    //Round Timer Variables
    private int seconds = 0;
    private float timer = 0.0f;
    private int roundTime = 300;

    // Start is called before the first frame update
    void Start()
    {
        seconds = roundTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;        
        seconds = roundTime - ((int)timer);

        DisplayTimer(seconds);
    }

    void DisplayTimer(int time)
    {
        int ones = 0;
        int tens = 0;
        int hundreds = 0;
        float fpointNum = 0.0f;

        
        hundreds = time / 100;    
        tens = (time % 100) / 10;
        ones = (time % 10);


        switch (hundreds)
        {
            case 0:
                zeroH.active = true;
                oneH.active = false;
                twoH.active = false;
                threeH.active = false;
                fourH.active = false;
                fiveH.active = false;
                sixH.active = false;
                sevenH.active = false;
                eightH.active = false;
                nineH.active = false;
                
                break;
            case 1:
                zeroH.active = false;
                oneH.active = true;
                twoH.active = false;
                threeH.active = false;
                fourH.active = false;
                fiveH.active = false;
                sixH.active = false;
                sevenH.active = false;
                eightH.active = false;
                nineH.active = false;
                break;
            case 2:
                zeroH.active = false;
                oneH.active = false;
                twoH.active = true;
                threeH.active = false;
                fourH.active = false;
                fiveH.active = false;
                sixH.active = false;
                sevenH.active = false;
                eightH.active = false;
                nineH.active = false;
                break;
            case 3:
                zeroH.active = false;
                oneH.active = false;
                twoH.active = false;
                threeH.active = true;
                fourH.active = false;
                fiveH.active = false;
                sixH.active = false;
                sevenH.active = false;
                eightH.active = false;
                nineH.active = false;
                break;
            case 4:
                zeroH.active = false;
                oneH.active = false;
                twoH.active = false;
                threeH.active = false;
                fourH.active = true;
                fiveH.active = false;
                sixH.active = false;
                sevenH.active = false;
                eightH.active = false;
                nineH.active = false;
                break;
            case 5:
                zeroH.active = false;
                oneH.active = false;
                twoH.active = false;
                threeH.active = false;
                fourH.active = false;
                fiveH.active = true;
                sixH.active = false;
                sevenH.active = false;
                eightH.active = false;
                nineH.active = false;
                break;
            case 6:
                zeroH.active = false;
                oneH.active = false;
                twoH.active = false;
                threeH.active = false;
                fourH.active = false;
                fiveH.active = false;
                sixH.active = true;
                sevenH.active = false;
                eightH.active = false;
                nineH.active = false;
                break;
            case 7:
                zeroH.active = false;
                oneH.active = false;
                twoH.active = false;
                threeH.active = false;
                fourH.active = false;
                fiveH.active = false;
                sixH.active = false;
                sevenH.active = true;
                eightH.active = false;
                nineH.active = false;
                break;
            case 8:
                zeroH.active = false;
                oneH.active = false;
                twoH.active = false;
                threeH.active = false;
                fourH.active = false;
                fiveH.active = false;
                sixH.active = false;
                sevenH.active = false;
                eightH.active = true;
                nineH.active = false;
                break;
            case 9:
                zeroH.active = false;
                oneH.active = false;
                twoH.active = false;
                threeH.active = false;
                fourH.active = false;
                fiveH.active = false;
                sixH.active = false;
                sevenH.active = false;
                eightH.active = false;
                nineH.active = true;
                break;
        }//End of hundreds

        switch (tens)
        {
            case 0:
                zeroT.active = true;
                oneT.active = false;
                twoT.active = false;
                threeT.active = false;
                fourT.active = false;
                fiveT.active = false;
                sixT.active = false;
                sevenT.active = false;
                eightT.active = false;
                nineT.active = false;

                break;
            case 1:
                zeroT.active = false;
                oneT.active = true;
                twoT.active = false;
                threeT.active = false;
                fourT.active = false;
                fiveT.active = false;
                sixT.active = false;
                sevenT.active = false;
                eightT.active = false;
                nineT.active = false;
                break;
            case 2:
                zeroT.active = false;
                oneT.active = false;
                twoT.active = true;
                threeT.active = false;
                fourT.active = false;
                fiveT.active = false;
                sixT.active = false;
                sevenT.active = false;
                eightT.active = false;
                nineT.active = false;
                break;
            case 3:
                zeroT.active = false;
                oneT.active = false;
                twoT.active = false;
                threeT.active = true;
                fourT.active = false;
                fiveT.active = false;
                sixT.active = false;
                sevenT.active = false;
                eightT.active = false;
                nineT.active = false;
                break;
            case 4:
                zeroT.active = false;
                oneT.active = false;
                twoT.active = false;
                threeT.active = false;
                fourT.active = true;
                fiveT.active = false;
                sixT.active = false;
                sevenT.active = false;
                eightT.active = false;
                nineT.active = false;
                break;
            case 5:
                zeroT.active = false;
                oneT.active = false;
                twoT.active = false;
                threeT.active = false;
                fourT.active = false;
                fiveT.active = true;
                sixT.active = false;
                sevenT.active = false;
                eightT.active = false;
                nineT.active = false;
                break;
            case 6:
                zeroT.active = false;
                oneT.active = false;
                twoT.active = false;
                threeT.active = false;
                fourT.active = false;
                fiveT.active = false;
                sixT.active = true;
                sevenT.active = false;
                eightT.active = false;
                nineT.active = false;
                break;
            case 7:
                zeroT.active = false;
                oneT.active = false;
                twoT.active = false;
                threeT.active = false;
                fourT.active = false;
                fiveT.active = false;
                sixT.active = false;
                sevenT.active = true;
                eightT.active = false;
                nineT.active = false;
                break;
            case 8:
                zeroT.active = false;
                oneT.active = false;
                twoT.active = false;
                threeT.active = false;
                fourT.active = false;
                fiveT.active = false;
                sixT.active = false;
                sevenT.active = false;
                eightT.active = true;
                nineT.active = false;
                break;
            case 9:
                zeroT.active = false;
                oneT.active = false;
                twoT.active = false;
                threeT.active = false;
                fourT.active = false;
                fiveT.active = false;
                sixT.active = false;
                sevenT.active = false;
                eightT.active = false;
                nineT.active = true;
                break;
        }//End of tens

        switch (ones)
        {
            case 0:
                zeroO.active = true;
                oneO.active = false;
                twoO.active = false;
                threeO.active = false;
                fourO.active = false;
                fiveO.active = false;
                sixO.active = false;
                sevenO.active = false;
                eightO.active = false;
                nineO.active = false;

                break;
            case 1:
                zeroO.active = false;
                oneO.active = true;
                twoO.active = false;
                threeO.active = false;
                fourO.active = false;
                fiveO.active = false;
                sixO.active = false;
                sevenO.active = false;
                eightO.active = false;
                nineO.active = false;
                break;
            case 2:
                zeroO.active = false;
                oneO.active = false;
                twoO.active = true;
                threeO.active = false;
                fourO.active = false;
                fiveO.active = false;
                sixO.active = false;
                sevenO.active = false;
                eightO.active = false;
                nineO.active = false;
                break;
            case 3:
                zeroO.active = false;
                oneO.active = false;
                twoO.active = false;
                threeO.active = true;
                fourO.active = false;
                fiveO.active = false;
                sixO.active = false;
                sevenO.active = false;
                eightO.active = false;
                nineO.active = false;
                break;
            case 4:
                zeroO.active = false;
                oneO.active = false;
                twoO.active = false;
                threeO.active = false;
                fourO.active = true;
                fiveO.active = false;
                sixO.active = false;
                sevenO.active = false;
                eightO.active = false;
                nineO.active = false;
                break;
            case 5:
                zeroO.active = false;
                oneO.active = false;
                twoO.active = false;
                threeO.active = false;
                fourO.active = false;
                fiveO.active = true;
                sixO.active = false;
                sevenO.active = false;
                eightO.active = false;
                nineO.active = false;
                break;
            case 6:
                zeroO.active = false;
                oneO.active = false;
                twoO.active = false;
                threeO.active = false;
                fourO.active = false;
                fiveO.active = false;
                sixO.active = true;
                sevenO.active = false;
                eightO.active = false;
                nineO.active = false;
                break;
            case 7:
                zeroO.active = false;
                oneO.active = false;
                twoO.active = false;
                threeO.active = false;
                fourO.active = false;
                fiveO.active = false;
                sixO.active = false;
                sevenO.active = true;
                eightO.active = false;
                nineO.active = false;
                break;
            case 8:
                zeroO.active = false;
                oneO.active = false;
                twoO.active = false;
                threeO.active = false;
                fourO.active = false;
                fiveO.active = false;
                sixO.active = false;
                sevenO.active = false;
                eightO.active = true;
                nineO.active = false;
                break;
            case 9:
                zeroO.active = false;
                oneO.active = false;
                twoO.active = false;
                threeO.active = false;
                fourO.active = false;
                fiveO.active = false;
                sixO.active = false;
                sevenO.active = false;
                eightO.active = false;
                nineO.active = true;
                break;
        }//End of ones


    }
}
