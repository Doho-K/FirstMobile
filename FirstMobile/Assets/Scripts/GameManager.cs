using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ScoreManager scoreManager;
    public AudioSource backgroundSound;
    public AudioSource deathSound;

    public Vector3 playerStartPoint;
    public Vector3 groundGenerationStartPoint;

    public GroundGenerator groundGenerator;

    public GameObject largeGround;
    public GameObject mediumGround;

    public GameObject gameOverScreen;

    void Start()
    {
        playerStartPoint = player.transform.position;//set player start point
        groundGenerationStartPoint = groundGenerator.transform.position;
        gameOverScreen.SetActive(false);//turn of gameover screen
    }

    public void GameOver()//when game over
    {
        player.gameObject.SetActive(false);//deactivate player
        gameOverScreen.SetActive(true);//turn on gameover screen
        scoreManager.isScoreIncreasing = false;//dont increase score
        backgroundSound.Stop();
        deathSound.Play();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Res()
    {
        GroundDestroyer[] destroyer = FindObjectsOfType<GroundDestroyer>();//get every object that have groundDestroyer
        for(int i =0; i < destroyer.Length; i++)//deactivate all the grounds
        {
            destroyer[i].gameObject.SetActive(false);

        }

        largeGround.SetActive(true);//activate initial ground
        mediumGround.SetActive(true);

        
        gameOverScreen.SetActive(false);
        Move();//move ground generator and player
        player.gameObject.SetActive(true);
        
        backgroundSound.Play();
        scoreManager.score = 0;//reset scores
        scoreManager.isScoreIncreasing = true;
    }

    public void Move()
    {
        groundGenerator.transform.position = groundGenerationStartPoint;
        player.transform.position = playerStartPoint;
    }

}
