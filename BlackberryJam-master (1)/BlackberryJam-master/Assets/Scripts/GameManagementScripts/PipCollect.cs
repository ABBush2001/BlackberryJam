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
    public AudioClip pip_pickup;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //update game manager
            GameObject temp = GameObject.FindWithTag("GameManager");
            temp.GetComponent<GameManager>().setPips(temp.GetComponent<GameManager>().getPips() - 1);

            AudioSource.PlayClipAtPoint(pip_pickup, transform.position);


            Destroy(this.gameObject);
        }
    }
}
