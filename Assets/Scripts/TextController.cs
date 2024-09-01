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
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] AudioSource playerDamaged;
    public int lives;
    private int score;
    private int highScore;
    [SerializeField] GameObject tank;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        score = 0;
        livesText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
               
    }

    public void ScoreIncrease()
    {
        score += 100;
        scoreText.text = "Score: " + score;
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        }
    }

    public void LifeLoss()
    {
        if (lives > 0)
        {
            playerDamaged.Play();
            lives -= 1;
            livesText.text = "Lives: " + lives;
        }
        if (lives < 1)
        {
            Destroy(tank);
        }
    }
}
