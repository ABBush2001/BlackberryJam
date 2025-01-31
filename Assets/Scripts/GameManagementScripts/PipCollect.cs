using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * This script handles the collision between the
 * player and the pips. When a player hits a pip,
 * it is destroyed.
*/
public class Pip : MonoBehaviour
{
    public AudioSource pipPickup;

    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        pipPickup = GameObject.Find("PipPickup").GetComponent<AudioSource>();
        scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        GameObject temp = GameObject.FindWithTag("GameManager");
        scoreText.text = "Score: " + temp.GetComponent<GameManager>().getScore();
    }

    //on trigger event for pip collision
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //update game manager
            GameObject temp = GameObject.FindWithTag("GameManager");
            temp.GetComponent<GameManager>().setPips(temp.GetComponent<GameManager>().getPips() - 1);
            temp.GetComponent<GameManager>().setScore(temp.GetComponent<GameManager>().getScore() + 5);

            scoreText.text = "Score: " + temp.GetComponent<GameManager>().getScore();

            pipPickup.Play();

            Destroy(this.gameObject);
        }
    }
}
