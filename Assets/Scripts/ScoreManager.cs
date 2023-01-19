using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    //public Text highscoreText;

    public int score = 0;
    public float highscore = 0;
    public int newscore = 0;
    float secondTimer = 0f;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        newscore = PlayerPrefs.GetInt("newscore", score);
        scoreText.text = score.ToString();
        //highscoreText.text = "HIGHSCORE: " + highscore.ToString() + "°F";

    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("newscore", score);
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
    }

    //public void MultiplyScore()
    //{
    //    score += 100;
    //    scoreText.text = score.ToString();
    //    PlayerPrefs.SetInt("newscore", score);
    //    //if (highscore < score)
    //    //    PlayerPrefs.SetInt("highscore", score);
    //}

    // Update is called once per frame
    void Update()
    {
        secondTimer = secondTimer + Time.deltaTime;
        if (secondTimer >= 1f)
        {
            AddScore();
            secondTimer = secondTimer - 1f;
        }
    }
}
