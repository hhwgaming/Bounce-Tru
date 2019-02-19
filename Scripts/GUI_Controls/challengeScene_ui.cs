using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class challengeScene_ui : MonoBehaviour {



	// Go Home Button
	public void gotoHome()
	{
		SceneManager.LoadScene ("Scenes/MainMenuScene");
	}

	// Level 1 Button
	public void gotoLevel1()
	{
		SceneManager.LoadScene ("Scenes/Levels/Level1"); // Load the level 1 scene and display it
	}
}
