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
        playerStartPoint = player.transform.position;
        groundGenerationStartPoint = groundGenerator.transform.position;
        gameOverScreen.SetActive(false);
    }

    public void GameOver()
    {
        player.gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
        scoreManager.isScoreIncreasing = false;
        backgroundSound.Stop();
        deathSound.Play();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Res()
    {
        GroundDestroyer[] destroyer = FindObjectsOfType<GroundDestroyer>();
        for(int i =0; i < destroyer.Length; i++)
        {
            destroyer[i].gameObject.SetActive(false);

        }

        largeGround.SetActive(true);
        mediumGround.SetActive(true);

        
        gameOverScreen.SetActive(false);
        Move();
        player.gameObject.SetActive(true);
        Debug.Log(player.transform.position.x + " after set active");
        
        backgroundSound.Play();
        scoreManager.score = 0;
        scoreManager.isScoreIncreasing = true;
    }

    public void Move()
    {
        groundGenerator.transform.position = groundGenerationStartPoint;
        player.transform.position = playerStartPoint;
        Debug.Log(player.transform.position.x + "x" +player.transform.position.y + "y"+"after reset");
        
    }

}
