using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script checks for collision between the 
 * player and the gun collectible
*/
public class GunTrigger : MonoBehaviour
{
    public AudioClip gunPickUp;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //update game manager
            GameObject temp = GameObject.FindWithTag("GameManager");
            temp.GetComponent<GameManager>().setGun();
            AudioSource.PlayClipAtPoint(gunPickUp, transform.position);

            Destroy(this.gameObject);
        }
    }
}
