using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour//this class is used for pool object
{
    public GameObject pooledObject;//object to pool
    public int numberOfObject;//number of object to pool
    private List<GameObject> gameObjects;//list to put objects of pooledObject

    void Start()
    {
        gameObjects = new List<GameObject>();//reset list
        for(int i = 0; i < numberOfObject; i++)//create initialize pooled object
        {
            GameObject gameObject = Instantiate(pooledObject);//create object
            gameObject.SetActive(false);//deactivate it
            gameObjects.Add(gameObject);//add it to list so can use later
        }
    }

    public GameObject GetPooledGameObject()//this method is get pooled object for generators
    {
        
        foreach(GameObject gameObject in gameObjects)//for every gameobjects in list
        {
            if (!gameObject.activeInHierarchy)//if gameObject is not active in hierarchy which mean can use that object
            {
                return gameObject;//then return that object to use
            }

        }
        //if every object in list are already used in game
        GameObject gameObj = Instantiate(pooledObject);//create more object
        gameObj.SetActive(false);
        gameObjects.Add(gameObj);
        return gameObj;//and return that object
    }

   
}
