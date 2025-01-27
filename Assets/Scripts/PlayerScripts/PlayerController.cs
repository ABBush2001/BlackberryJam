using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is script handles player movement with the WASD keys.
 * It checks the position of the camera to make sure the player
 * is moving in the direction the camera is facing. The script is
 * partially based on the player movement script designed by The
 * Game Dev Cave. Their video is linked here:
 * https://www.youtube.com/watch?v=reWtxGTyN78&ab_channel=TheGameDevCave
*/

public class PlayerController : MonoBehaviour
{
    //variables for movement speed, player rigidbody,
    //and the main camera
    public float moveSpeed;

    private Rigidbody rb;

    [SerializeField] Transform Cam;

    //initialize the value of the rigidbody
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    //check for player movement and update position accordingly
    private void Update()
    {
        //get input and convert to movement
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;
        float verticalMovement = Input.GetAxis("Vertical") * moveSpeed;

        //get camera position
        Vector3 camForward = Cam.forward;
        Vector3 camRight = Cam.right;

        //set camera y values to 0 so we don't move player vertically
        camForward.y = 0;
        camRight.y = 0;

        //create vectors for camera-relative movement
        Vector3 forwardRelative = verticalMovement * camForward;
        Vector3 rightRelative = horizontalMovement * camRight;

        Vector3 moveDir = forwardRelative + rightRelative;

        //update player velocity
        rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);
    }
}
