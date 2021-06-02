using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//this is for UI

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
        isScoreIncreasing = true;//when start, score starts increase
        if (PlayerPrefs.HasKey("HighScore"))//if there is a data of highscore
        {
            highscore = PlayerPrefs.GetFloat("HighScore");//then set current highscore as saved highscore
        }
    }

    void Update()
    {
        if(isScoreIncreasing)//if score increasement is allowed
            score += pointsPerSecond * Time.deltaTime;//increase score by time

        if(score > highscore)//if current score is higher than highscore
        {
            highscore = score;//set highscore as current score
            PlayerPrefs.SetFloat("HighScore", highscore);//and save it
        }
        scoreText.text = Mathf.Round(score).ToString();//change it to string and integer to show on text
        highscoreText.text = Mathf.Round(highscore).ToString();
    }
}
