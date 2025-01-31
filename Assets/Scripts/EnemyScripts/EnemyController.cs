using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").transform;
        gameManager = GameObject.FindWithTag("GameManager");

        //set speed
        int level = gameManager.GetComponent<GameManager>().getLevel();

        if (level > 1)
        {
            agent.speed = 2 + level;
        }
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;
    }
}
