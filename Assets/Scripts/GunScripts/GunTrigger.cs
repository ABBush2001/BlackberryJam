using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script checks for collision between the 
 * player and the gun collectible
*/
public class GunTrigger : MonoBehaviour
{
    public GameObject gunUI;
    public AudioSource gunPickup;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //update game manager
            GameObject temp = GameObject.FindWithTag("GameManager");
            temp.GetComponent<GameManager>().setGun();
            gunPickup.Play();

            //turn on UI
            gunUI.SetActive(true);

            Destroy(this.gameObject);
        }
    }
}
