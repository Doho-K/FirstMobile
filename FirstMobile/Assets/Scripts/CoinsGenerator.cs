using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGenerator : MonoBehaviour
{
    public ObjectPooler coinPooler;//call objectpooler of coin

    public void SpawnCoins(Vector3 position,float groundWidth)//when this method called, spawn coins on position
    {
        int random = Random.Range(1, 100);//making chance to spawn coin or not
        if (random < 60)
        {
            return;
        }
        int numberOfCoins = (int)Random.Range(3f,groundWidth);//set random number of coin to spawn
        float y = Random.Range(2, 4);//set random y position to spawn coin
        for(int i = 0; i < numberOfCoins; i++)
        {
            GameObject coin = coinPooler.GetPooledGameObject();//set pooled object to coin
            float x = position.x - (groundWidth / 2) + 1;//set x coordinate to spawn coins
            
            coin.transform.position = new Vector3(x+i, y, 0);

            coin.SetActive(true);
        }
        
    }
}
