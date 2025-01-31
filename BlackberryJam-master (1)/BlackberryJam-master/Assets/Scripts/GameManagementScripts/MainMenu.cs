using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    // Add this scene to your build. In the LoadScene part, put the main game level index
	// or the level name string (as "levelname Example") inbetween the parentheses. 
    public void PlayGame()
	{
		SceneManager.LoadScene(1);
	}
	
	public void Quit()
	{
		Application.Quit();
	}
}
