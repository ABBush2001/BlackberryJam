using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script allows the gun picked up by players to
 * be shot. It uses ray tracing to determine if anything
 * is hit. Unity forums posts were used as references for
 * how to properly perform raycasting, linked here:
 * https://discussions.unity.com/t/raycast-bullet/741592/5
 * https://discussions.unity.com/t/how-to-check-if-raycast-hits-a-certain-object/248279/3
*/
public class GunShoot : MonoBehaviour
{
    public int numBullets;
    private GameObject temp;
    public GameObject enemySpawner;
    public GameObject gunUI;

    private void Awake()
    {
        numBullets = 3;
        temp = GameObject.FindWithTag("GameManager");
        enemySpawner = GameObject.Find("EnemyStart");
    }

    // Update is called once per frame
    void Update()
    {
        //check if user shot
        if(temp.GetComponent<GameManager>().getGun() && Input.GetKeyDown(KeyCode.Mouse0))
        {
            //create raycast hit
            Ray ray;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //check if raycast hit an enemy
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Enemy")
                {
                    enemySpawner.GetComponent<EnemySpawning>().numEnemies -= 1;
                    Destroy(hit.collider.gameObject);
                }
            }

            //decrease bullet count
            numBullets -= 1;
            gunUI = GameObject.FindWithTag("Gun");
            Destroy(gunUI.transform.GetChild(0).GetChild(0).gameObject);

            //check if out of bullets
            if (numBullets == 0)
            {
                temp.GetComponent<GameManager>().setGun();
                gunUI = GameObject.Find("AmmoPanel");
                gunUI.SetActive(false);
            }
        }
    }
}
