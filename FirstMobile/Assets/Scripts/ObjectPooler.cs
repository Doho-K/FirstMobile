using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject;
    public int numberOfObject;
    private List<GameObject> gameObjects;

    void Start()
    {
        gameObjects = new List<GameObject>();
        for(int i = 0; i < numberOfObject; i++)
        {
            GameObject gameObject = Instantiate(pooledObject);
            gameObject.SetActive(false);
            gameObjects.Add(gameObject);
        }
    }

    public GameObject GetPooledGameObject()//this function is used in groundgenerator
    {
        
        foreach(GameObject gameObject in gameObjects)//for every gameobjects in list gameobjects
        {
            if (!gameObject.activeInHierarchy)//if gameObject is not active in hierarchy
            {
                return gameObject;//then return that ground to spawn
            }

        }

        GameObject gameObj = Instantiate(pooledObject);//if every ground are active then make more ground
        gameObj.SetActive(false);
        gameObjects.Add(gameObj);
        return gameObj;
    }

   
}
