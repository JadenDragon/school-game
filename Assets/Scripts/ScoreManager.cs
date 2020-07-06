using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int currentScore = 0;
    public static int score;

    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();

        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "working " + currentScore;
    }

    internal void AddScore(int amount)
    {
        //adds amount to currentScore
        currentScore += amount;
        Debug.Log("Current Score = " + currentScore);

        //text.text = "Score: " + currentScore;
        //changes display text to "score" + scoreValue
        //score += amount;

    }
}
