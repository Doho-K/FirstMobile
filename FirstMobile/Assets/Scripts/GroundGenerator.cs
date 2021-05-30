using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public Transform groundPoint;
    public ObjectPooler[] groundPoolers;
    private float[] groundWidths
    // Start is called before the first frame update
    void Start()
    {
        groundWidths = new float[groundPoolers.Length];
        for(int i =0; i<groundPoolers.Length; i++)
        {
            groundWidths[i] = groundPoolers[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < groundPoint.position.x)
        {

        }
    }
}
