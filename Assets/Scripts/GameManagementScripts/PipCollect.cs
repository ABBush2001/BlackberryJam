using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script handles the collision between the
 * player and the pips. When a player hits a pip,
 * it is destroyed.
*/
public class Pip : MonoBehaviour
{

    //on trigger event for pip collision
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //update game manager
            GameObject temp = GameObject.FindWithTag("GameManager");
            temp.GetComponent<GameManager>().setPips(temp.GetComponent<GameManager>().getPips() - 1);

            Destroy(this.gameObject);
        }
    }
}
