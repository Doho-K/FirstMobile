using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public float pointsPerSecond;

    public Text scoreText;
    public Text highscoreText;

    public float score;
    private float highscore;

    public bool isScoreIncreasing;
    void Start()
    {
        isScoreIncreasing = true;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highscore = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isScoreIncreasing)
            score += pointsPerSecond * Time.deltaTime;

        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetFloat("HighScore", highscore);
        }
        scoreText.text = Mathf.Round(score).ToString();
        highscoreText.text = Mathf.Round(highscore).ToString();
    }
}
