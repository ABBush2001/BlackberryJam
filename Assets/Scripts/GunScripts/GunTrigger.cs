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
    GameObject temp;

    private void Awake()
    {
        temp = GameObject.FindWithTag("GameManager");
        Debug.Log(temp.GetComponent<GameManager>().getAmmo());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && temp.GetComponent<GameManager>().getGun() == false)
        {
            //update game manager
            temp.GetComponent<GameManager>().setGun();
            gunPickup.Play();

            //turn on UI
            gunUI.SetActive(true);

            Destroy(this.gameObject);
        }
    }

}
