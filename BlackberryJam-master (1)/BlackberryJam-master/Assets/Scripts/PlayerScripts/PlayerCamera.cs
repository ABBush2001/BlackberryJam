using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script allows the player to move the camera with their
 * mouse, allowing them to look around the level. Mouse sensitivity
 * is an easily adjusted variable that can be changed in settings.
 * This script is attached to the main camera.
 * 
 * This script was originally designed by Reddit user krenuds in the post
 * linked here: 
 * https://www.reddit.com/r/Unity3D/comments/8k7w7v/unity_simple_mouselook/
*/

public class PlayerCamera : MonoBehaviour
{
    //variables for rotation and mouse sensitivity
    Vector2 rotation = Vector2.zero;
    public float speed = 5;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //update camera rotation based on mouse movement.
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)rotation * speed;
    }
}
