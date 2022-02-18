using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateScoreScript : MonoBehaviour
{

    public Text bowlingScore;
    public static int bowlingScoreNum;
    public GameObject[] pins;
    private static bool knockedFlag;

    public GameObject endLevelUi;

    // Start is called before the first frame update
    void Start()
    {
        bowlingScoreNum = 0;
        
    }


    void OnTriggerEnter(Collider colliderInfo)
    {
        if (colliderInfo.tag == "Player")
        {
            if(gameObject.tag == "endGame")
            {
                Debug.Log("end level");
                //freeze player movement
                GameObject.Find("Player").GetComponent<playerMovementScript>().enabled = false;
                StartCoroutine(delay());

            }
            else
            {
                countKnockedPins();
            }


        }
    }

    public void countKnockedPins()
    {
        for (int i = 0; i < 10; i++)
        {
            knockedFlag = pins[i].GetComponent<isKnockedOverScript>().isKnocked;

            if (knockedFlag)
                bowlingScoreNum++;



            //bowlingScore = updateScoreScript.bowlingScoreNum;
            // bowlingScoreText.text = "Score: " + bowlingScore.ToString();
        }
        //after you check all of the values and update the score, reset knockedFlag to false
        knockedFlag = false;
        Debug.Log("update score");
    }

    IEnumerator delay()
    {
        //This is a coroutine
        Debug.Log("before");

        yield return new WaitForSeconds(3);    //Wait one frame

        Debug.Log("after");
        //method to call after coroutine???
        countKnockedPins();
        //endLevelUi.GetComponent<>
        endLevelUi.SetActive(true);
    }

}
