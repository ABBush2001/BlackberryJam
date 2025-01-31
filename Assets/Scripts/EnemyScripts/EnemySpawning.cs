using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script handles enemy spawning. It keeps a count of how
 * many enemies are in the level, and what level the player is on.
 * It spaces spawning out so enemies spawn in intervals
*/
public class EnemySpawning : MonoBehaviour
{
    public int numEnemies;
    private int numToSpawn;

    public GameObject enemy;
    public GameObject enemyStartingPoint;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        numEnemies = 3;
        numToSpawn = 3;
        gameManager = GameObject.FindWithTag("GameManager");
        StartCoroutine(enemySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        if(numEnemies < 3)
        {
            numToSpawn = 3 - numEnemies;
            StartCoroutine(enemySpawner());
            numEnemies = 3;
        }
    }

    IEnumerator enemySpawner()
    {
        for(int i = 0; i < numToSpawn; i++)
        {
            yield return new WaitForSeconds(Random.Range(5, 8));
            GameObject temp = Instantiate(enemy, enemyStartingPoint.transform);
        }
    }
}
