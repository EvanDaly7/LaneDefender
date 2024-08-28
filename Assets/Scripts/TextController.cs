/*****************************************************************************
// File Name : TextController.cs
// Author : Evan J. Daly
// Creation Date : August 25, 2024
//
// Brief Description : Updates text with info about lives and scores.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField] TMP_Text livesText;
    [SerializeField] TMP_Text scoreText;
    private int lives;
    private int score;
    [SerializeField] GameObject tank;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        score = 0;
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
               
    }

    public void ScoreIncrease()
    {
        score += 100;
        scoreText.text = "Score: " + score;
    }

    public void LifeLoss()
    {
        lives -= 1;
        livesText.text = "Lives: " + lives;
        if (lives < 1)
        {
            Destroy(tank);
        }
    }
}
