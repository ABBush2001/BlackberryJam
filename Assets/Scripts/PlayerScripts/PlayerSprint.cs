using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * This script checks how long the player is sprinting for,
 * activating the UI sprint bar when they are sprinting and disabling
 * the sprint when the bar is emptied. This script is attached to the
 * game manager object
*/
public class PlayerSprint : MonoBehaviour
{
    public Slider sprintSlider;
    public GameObject player;
    public bool sprintWait;

    // Start is called before the first frame update
    void Start()
    {
        sprintWait = false;
    }

    // Update is called once per frame
    void Update()
    {
        //check if in correct scene
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            

            if (player.GetComponent<PlayerController>().getSprint() && sprintSlider.value > 0)
            {
                sprintSlider.gameObject.SetActive(true);
                sprintSlider.value -= 0.5f * Time.deltaTime;
            }
            else if (sprintSlider.value <= 0)
            {
                if (sprintWait != true)
                {
                    sprintWait = true;
                    StartCoroutine(reloadSprint());
                }
            }
            else if (sprintSlider.value < 1 && sprintWait == false)
            {
                StartCoroutine(reloadSprint());
            }
            else if (sprintSlider.value == 1 && sprintWait == false)
            {
                sprintSlider.gameObject.SetActive(false);
            }
        }

    }

    IEnumerator reloadSprint()
    {
        while(sprintSlider.value < 1)
        {
            yield return new WaitForSeconds(0.01f);
            sprintSlider.value += 0.005f;
        }

        sprintWait = false;
    }

}
