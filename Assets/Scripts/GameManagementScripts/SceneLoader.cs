using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script allows for movement between game scenes.
*/
public class SceneLoader : MonoBehaviour
{
    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void lastScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void loadMainScene()
    {
        SceneManager.LoadScene(1);
    }
    public void loadLoseScene()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByName("Game_Over").buildIndex);
    }
    public void loadWinScene()
    {
        SceneManager.LoadScene(2);
    }
}
