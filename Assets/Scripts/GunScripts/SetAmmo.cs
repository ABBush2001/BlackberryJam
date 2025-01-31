using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script sets how much ammo the player has
 * based on the level they are on. Each level, the ammo
 * is increased by 1, up until level 5
*/
public class SetAmmo : MonoBehaviour
{
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");

        if(gameManager.GetComponent<GameManager>().getLevel() == 1)
        {
            gameManager.GetComponent<GameManager>().setAmmo(3);
        }
        if (gameManager.GetComponent<GameManager>().getLevel() == 2)
        {
            gameManager.GetComponent<GameManager>().setAmmo(4);
        }
        if (gameManager.GetComponent<GameManager>().getLevel() == 3)
        {
            gameManager.GetComponent<GameManager>().setAmmo(5);
        }
        if (gameManager.GetComponent<GameManager>().getLevel() == 4)
        {
            gameManager.GetComponent<GameManager>().setAmmo(6);
        }
        if (gameManager.GetComponent<GameManager>().getLevel() == 5)
        {
            gameManager.GetComponent<GameManager>().setAmmo(7);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
