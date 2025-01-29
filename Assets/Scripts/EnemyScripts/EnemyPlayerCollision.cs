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

    private void Awake()
    {
        gameManager = GameObject.FindWithTag("GameManager");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameManager.GetComponent<GameManager>().setLives(gameManager.GetComponent<GameManager>().getLives() - 1);
            Destroy(this.gameObject);
        }
    }
}
