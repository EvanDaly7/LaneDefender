using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{
    [SerializeField] TMP_Text livesText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] AudioSource playerDamaged;
    public int lives;
    private int score;
    [SerializeField] GameObject tank;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText.enabled = false;
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

    //Called whenever the score needs to increase.
    public void ScoreIncrease()
    {
        score += 100;
        scoreText.text = "Score: " + score;
        //Checks if score is greater than the high score and sets high score to player score.
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        }
    }

    //Called whenever the player losses a life.
    public void LifeLoss()
    {
        if (lives > 0)
        {
            playerDamaged.Play();
            lives -= 1;
            livesText.text = "Lives: " + lives;
        }
        //Destroys player tank if out of lives.
        if (lives < 1)
        {
            gameOverText.enabled = true;
            Destroy(tank);
        }
    }

    public void OnRestart()
    {
        SceneManager.LoadScene(0);
    }
}
