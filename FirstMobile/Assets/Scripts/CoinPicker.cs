using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    public AudioSource coinPickSound;
    private float coinPoints = 15f;
    private ScoreManager scoreManager;
    private void Start()
    {
        coinPickSound = GameObject.Find("CoinPickSound").GetComponent<AudioSource>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {

            gameObject.SetActive(false);
            if (coinPickSound.isPlaying)
            {
                coinPickSound.Stop();
            }
            coinPickSound.Play();
            scoreManager.score += coinPoints;
        }
    }
}
