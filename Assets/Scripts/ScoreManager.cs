using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //private int currentScore = 0;
    //Text text;
    public static int theScore;

    private void Awake()
    {
        //scoreText = GetComponent<Text>();
        theScore = 0;
        
    }

    // Update is called once per frame
    private void Update()
    {
        //text.text = "working " + theScore;
        GetComponent<Text>().text = "Score: " + theScore;
        Debug.Log("Score is being updated");
    }

    /*internal void AddScore(int amount)
    {
        //adds amount to currentScore
        currentScore += amount;
        Debug.Log("Current Score = " + currentScore);

        //text.text = "Score: " + currentScore;
        //changes display text to "score" + scoreValue
        //score += amount;

    }*/
}
