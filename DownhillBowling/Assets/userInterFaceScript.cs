using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class userInterFaceScript : MonoBehaviour
{

    public Text bowlingScoreText;
    private static int bowlingScore;
    // Start is called before the first frame update
    void Start()
    {
        bowlingScoreText.text = "Score: ";
    }

    // Update is called once per frame
    void Update()
    {

        bowlingScore = updateScoreScript.bowlingScoreNum;
        bowlingScoreText.text = "Score: " + bowlingScore.ToString();

    }
}
