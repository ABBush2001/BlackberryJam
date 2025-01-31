using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script handles collision between the player and the enemy. On
 * Collision, the enemy is destroyed and the player loses a life.
*/
public class EnemyPlayerCollision : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    public GameObject lives;

    private void Awake()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        lives = GameObject.Find("LivesPanel");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameManager.GetComponent<GameManager>().setLives(gameManager.GetComponent<GameManager>().getLives() - 1);
            Destroy(lives.transform.GetChild(1).GetChild(0).GetChild(0).gameObject);
            Destroy(this.gameObject);
        }
    }
}
