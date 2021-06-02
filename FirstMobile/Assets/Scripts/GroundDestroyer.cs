using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour
{
    private GameObject point;
    
    void Start()
    {
        point = GameObject.Find("GroundEndPoint");//find point that this object will be deactivate
    }

    void Update()
    {
        if (transform.position.x < point.transform.position.x)//if this object's x position is less than point position
        {
            gameObject.SetActive(false);//then deactivate it
        }
    }
}
