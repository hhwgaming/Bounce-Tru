using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class main_menu : MonoBehaviour {

	 
	// The Play Button
	public void play_btn()
	{
		SceneManager.LoadScene ("Scenes/infinitePlayScene"); // Load and display the infinite scene
	}

	// The Challenge Button
	public void challenge_btn()
	{
		SceneManager.LoadScene ("Scenes/challengeMenuScene"); // Load and display the challenge menu scene
	}

	// The Option Button
	public void option_btn()
	{
		SceneManager.LoadScene ("Scenes/optionScene"); // Load and display the option scene
	}

	// Looping at every fps
	void Update(){

		if (Input.GetKey (KeyCode.Escape)) // Checks if the escape key is pressed on windows or back button on mobile devices 
		{
			Application.Quit (); // It closes the application
		}
	}
}
