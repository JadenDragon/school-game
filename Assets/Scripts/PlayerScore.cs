using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private int currentScore = 0;

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void AddScore(int amount)
    {
        //adds amount to currentScore
        currentScore += amount;
        Debug.Log("Current Score = " + currentScore);
    }
}
