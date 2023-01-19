using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSaver : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;

    public int score = ScoreManager.instance.newscore;
    public float highscore = ScoreManager.instance.highscore;



    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        score = PlayerPrefs.GetInt("newscore", 0);
        scoreText.text = "Current Score: " + score.ToString();
        highscoreText.text = "Best Score: " + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
