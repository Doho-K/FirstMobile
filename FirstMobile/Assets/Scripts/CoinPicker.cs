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
        coinPickSound = GameObject.Find("CoinPickSound").GetComponent<AudioSource>();//automatically set audio source of coin pick sound
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")//when coin collided with player
        {

            gameObject.SetActive(false);//deactivate coin
            if (coinPickSound.isPlaying)//play coin sound and stop
            {
                coinPickSound.Stop();
            }
            coinPickSound.Play();
            scoreManager.score += coinPoints;//add coin point
        }
    }
}
