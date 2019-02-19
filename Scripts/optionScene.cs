using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class optionScene : MonoBehaviour {



	// Go Home Button
	public void gotoHome(){

		SceneManager.LoadScene ("Scenes/MainMenuScene"); // Load the main menu scene and display it

	}
}
