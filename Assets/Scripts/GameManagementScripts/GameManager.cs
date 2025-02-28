using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script keeps track of in-game events, and persists between scenes
 * via a game object.
*/
public class GameManager : MonoBehaviour
{
    //variables
    [SerializeField] private int level = 1;
    [SerializeField] private int pips = 77;
    [SerializeField] private int lives = 3;
    [SerializeField] private float score = 0;
    [SerializeField] private int ammo = 3;
    [SerializeField] private bool hasGun = false;

    //instance of game manager for persistence
    public static GameManager instance;

    //Awake method for persistence
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //ammo
    public void setAmmo(int a)
    {
        ammo = a;
    }
    public int getAmmo()
    {
        return ammo;
    }

    //score
    public void setScore(float a)
    {
        score = a;
    }
    public float getScore()
    {
        return score;
    }

    //level
    public void nextLevel()
    {
        level += 1;
    }
    public int getLevel()
    {
        return level;
    }

    //pips
    public void setPips(int a)
    {
        pips = a;
    }
    public int getPips()
    {
        return pips;
    }

    //lives
    public void setLives(int a)
    {
        lives = a;
    }
    public int getLives()
    {
        return lives;
    }

    //gun
    public void setGun()
    {
        if(hasGun == false)
        {
            hasGun = true;
            GameObject temp = GameObject.FindWithTag("Player").transform.GetChild(0).transform.GetChild(0).gameObject;
            temp.SetActive(true);
        }
        else
        {
            hasGun = false;
            GameObject temp = GameObject.FindWithTag("Player").transform.GetChild(0).transform.GetChild(0).gameObject;
            temp.SetActive(false);
        }
    }
    public bool getGun()
    {
        return hasGun;
    }

    private void Update()
    {
        //if all pips are collected
        if (pips == 0)
        {
            pips = 77;
            nextLevel();
            this.gameObject.GetComponent<SceneLoader>().loadWinScene();
        }

        //if player runs out of lives
        if(lives == 0)
        {
            lives = 3;
            this.gameObject.GetComponent<SceneLoader>().loadLoseScene();
        }
    }
}
