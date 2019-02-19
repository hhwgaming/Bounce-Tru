using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class infiniteSceen_ui : MonoBehaviour {

	// Declaration
	[SerializeField] private   Text textUI; // Text to display scores
	[SerializeField] private   GameObject pause_panel; // The panel for pause menus
	[SerializeField] private   Image[] level; // Images of various level
	[SerializeField] private   Sprite sprite; // Sprite for every level reached
	 
	private static int checkPoint = 0;
	private static int scores = 0;
	 

	private SpriteRenderer sprite_render;

	void Start()
	{
		scores = 0; // Set count to zero
		sprite_render = GameObject.Find ("playing_background").GetComponent<SpriteRenderer> (); // Get the sprite component of background
	}

	void Update()
	{
		 textUI.text =   scores+""; // set the text score to display the count value
		 
		switch(checkPoint) // check the value variation at each point
		{
		case 1050:
			level[0].sprite = sprite; // Set the previous image level to a new image
			sprite_render.color = new Color (0.8962f, 0.4861f, 0.4861f); // Change the background colour
			break;
		case 950:
			level[1].sprite = sprite; // Set the previous image level to a new image
			break;
		case 900:
			level[2].sprite = sprite; // Set the previous image level to a new image
			sprite_render.color = new Color (0.7830f, 0.2917f, 0.2917f); // Change the background colour
			break;
		case  850:
			level[3].sprite = sprite; // Set the previous image level to a new image
			break;
		case 800:
			level[4].sprite = sprite; // Set the previous image level to a new image
			sprite_render.color = new Color (0.7358f, 0.0659f, 0.0659f); // Change the background colour
			break;


		}

	}
 
	// Reads the scores when ever player successfully pass through ring
	public  static void updateScore()
	{
		 scores = scores + 1; // Increase the scores by 1 value
	 } 
  



	// Go Home Button
	public void gotoHome()
	{
		SceneManager.LoadScene ("MainMenuScene"); // Load and display the main menu scene
	}
	 

	// Button to pause Game
	public void pauseGame()
	{
		pause_panel.SetActive (true); // Display the pause panel on the scene
		PlayerMovement.pausePlayer (true); // Set player movement to true
		OpponentRings.pauseOpponent (true); // Set opponent movement to true
	}

	// Button to resume game
	public void resumeGame()
	{
		pause_panel.SetActive (false); // Hide the pause panel on the scene
		PlayerMovement.pausePlayer (false); // Set player movement to false
		OpponentRings.pauseOpponent (false); // Set opponent movement to false
	}


	// A Method that reads the level rate as the game plays
	public static void rising_level(int value)
	{
		checkPoint = value; // set the value to max time
	}

}
