using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public Renderer background;
    public float backgroundSpeed;//background's scroll speed

    
    void Update()
    {
        background.material.mainTextureOffset += new Vector2(backgroundSpeed*Time.deltaTime,0f);//by increasing texture offset scroll background
    }
}
