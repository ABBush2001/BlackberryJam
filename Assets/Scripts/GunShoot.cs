using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script allows the gun picked up by players to
 * be shot. It uses ray tracing to determine if anything
 * is hit. Unity forums posts were used as references for
 * how to properly perform raycasting, linked here:
 * https://discussions.unity.com/t/raycast-bullet/741592/5
 * https://discussions.unity.com/t/how-to-check-if-raycast-hits-a-certain-object/248279/3
*/
public class GunShoot : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //check if user shot
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            //create raycast hit
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //check if raycast hit an enemy
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Enemy")
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
