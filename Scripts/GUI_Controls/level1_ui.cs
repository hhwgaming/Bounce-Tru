using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class level1_ui : MonoBehaviour {

	// Variable Declaration
	[SerializeField] private GameObject pause_panel;
	[SerializeField] private GameObject gameInfo;
	[SerializeField] private GameObject finishZone;
	[SerializeField] private   Text textUI;
	[SerializeField] private   Image[] star;
	[SerializeField] private   Sprite sprite;
	private float timeDelay = 0.0f;
	private static int scores = 0;
	private float incrementer = 10.0f;
	 
	private static bool showEndBanner = false;
	 
	void Start () {
		
		level1.pauseOpponent (true);// pause the opponent movement
		LevelsPlayer.pausePlayer (true); // pause the player controls
		showEndBanner = false; // Hide end banner
		 
		scores = 0;
	}

	// Update is called once per frame
	void Update () 
	{
		timeDelay = timeDelay +incrementer; // Increase the time counter by 10 points

		if (timeDelay == 1000) // If time delay is greater than 1000
		{
			gameInfo.SetActive (false); // Hide the Game info panel
			level1.pauseOpponent (false); //Activates the opponent
			LevelsPlayer.pausePlayer (false); // Activate the player
			timeDelay = 2000.0f; // stop the time delay counter
		}

		textUI.text =   scores+""; // Update the score board


		switch(scores) // check the value variation at each point
		{
			case 1:
			star[0].sprite = sprite; // Set the previous image level to a new image
				break;
			case 2:
			star[1].sprite = sprite; // Set the previous image level to a new image
				break;
			case 3:
			star[2].sprite = sprite; // Set the previous image level to a new image
				break;

		}
		if (showEndBanner)
		{
			finishZone.SetActive (true); // Show the finish line tag
		}

	}

	public  static void updateScores()
	{
		scores = scores + 1; // Increase the scores by 1 value
	} 
 

	public static void showCompletionBanner(){
		showEndBanner = true;  
		LevelsPlayer.pausePlayer (true); // Set player movement to true
		level1.pauseOpponent (true); // Set opponent movement to true
	}


	public void pauseGame(){

		pause_panel.SetActive (true); // Display the pause panel on the scene
		LevelsPlayer.pausePlayer (true); // Set player movement to true
		level1.pauseOpponent (true); // Set opponent movement to true
	}

	// Button to resume game
	public void resumeGame()
	{
		pause_panel.SetActive (false); // Hide the pause panel on the scene
		LevelsPlayer.pausePlayer (false); // Set player movement to false
		level1.pauseOpponent (false); // Set opponent movement to false
	}

	// Challenge button
	public void returnToChallenge()
	{
		
		SceneManager.LoadScene ("Scenes/challengeMenuScene"); //Load and show the challenge scene
	}

	//Repeat Game
	public void repeatGame()
	{
		
		SceneManager.LoadScene ("Scenes/Levels/level1"); //Load and show the level1 scene
	}
	  
}
