using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public Transform groundPoint;
    public Transform minHeightPoint;
    public Transform maxHeightPoint;

    private float minY;
    private float maxY;

    public float minGap;
    public float maxGap;
    public ObjectPooler[] groundPoolers;//array to put poolers of ground
    private float[] groundWidths;//array to put widths or grounds

    private CoinsGenerator coinGenerator;
    void Start()
    {

        minY = minHeightPoint.position.y;
        maxY = maxHeightPoint.position.y;
        groundWidths = new float[groundPoolers.Length];
        for(int i =0; i<groundPoolers.Length; i++)
        {
            groundWidths[i] = groundPoolers[i].pooledObject.GetComponent<BoxCollider2D>().size.x;//save width of every ground
        }
        coinGenerator = FindObjectOfType<CoinsGenerator>();
    }

    void Update()
    {
        if(transform.position.x < groundPoint.position.x)//if generator's x coordinate is smaller than groundpoint's
        {
            int random = Random.Range(0,groundPoolers.Length);//chose random ground to spawn
            float distance = groundWidths[random];//set distance as that ground width
            float gap = Random.Range(minGap, maxGap);//chose random gap between ground
            float height = Random.Range(minY, maxY);//chose random height between min and max

            transform.position = new Vector3(transform.position.x + distance + gap, height, transform.position.z);//move position to spawn ground

            GameObject ground = groundPoolers[random].GetPooledGameObject();//get pooled gameobject 
            ground.transform.position = transform.position;//move that ground to generator's position
            ground.SetActive(true);//activate it

            coinGenerator.SpawnCoins(transform.position,groundWidths[random]);//spawn coins

        }
    }
}
