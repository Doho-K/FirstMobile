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
    public void Restart()
    {
        GroundDestroyer[] destroyer = FindObjectsOfType<GroundDestroyer>();
        for(int i =0; i < destroyer.Length; i++)
        {
            destroyer[i].gameObject.SetActive(false);

        }

        largeGround.SetActive(true);
        mediumGround.SetActive(true);

        
        gameOverScreen.SetActive(false);
        player.gameObject.SetActive(true);
        player.transform.position = playerStartPoint;
        groundGenerator.transform.position = groundGenerationStartPoint;
        backgroundSound.Play();
        scoreManager.score = 0;
        scoreManager.isScoreIncreasing = true;
    }

}
