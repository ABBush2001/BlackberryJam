using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    //Reference to player transform
    public Transform player;

    //Late update function to trigger after update and fixed update
    void LateUpdate()
    {
        //Update minimaps camera to follow player position
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}

