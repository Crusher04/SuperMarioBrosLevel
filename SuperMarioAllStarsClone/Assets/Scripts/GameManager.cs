using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Coins Numbers")]
    public GameObject zeroT, oneT, twoT, threeT, fourT, fiveT, sixT, sevenT, eightT, nineT;
    public GameObject zeroO, oneO, twoO, threeO, fourO, fiveO, sixO, sevenO, eightO, nineO;
    private int amountOfCoins = 0;

    [Header("Game Music")]
    public AudioSource mapScreen;
    public AudioSource levelOne;
    public AudioSource levelOneHurry;
    public AudioSource levelEnter;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCoins(amountOfCoins);
    }

    public void UpdateCoins()
    {
        Debug.Log("COIN UPDATED");
        amountOfCoins++;
    }

    private void DisplayCoins(int numOfCoins)
    {
        int ones = 0;
        int tens = 0;
        tens = (numOfCoins % 100) / 10;
        ones = (numOfCoins % 10);

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
