using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Player player;
    private Vector3 lastPosition;
    private float distance;

    void Start()
    {
        player = FindObjectOfType<Player>();//find player to chase
        lastPosition = player.transform.position;//set initial position of player
    }

    void FixedUpdate()
    {
        distance = player.transform.position.x - lastPosition.x;//calculate distance of player moved
        transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);//change camera position
        lastPosition = player.transform.position;//set last position again
    }
}
