using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultsScreen : MonoBehaviour
{

    int finalScore;
    public Text scoreValueText;

    // Use this for initialization
    void Start()
    {
        finalScore = ScoreUI.score;
        scoreValueText.text = finalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
