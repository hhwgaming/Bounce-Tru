using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	// Variable Declaration
	private static Rigidbody2D  rigidBody; 
	public float up = 6f;
	public float gravity = 0.5f;
	static bool isPlayerMovable;
	 
	 // Initialise the Game
	void Start () {

		rigidBody = GetComponent<Rigidbody2D> (); // Get the rigid body component for the player
		rigidBody.gravityScale = gravity; // Set the gravity value for the player
		isPlayerMovable = true; // Set player movement to true

	}


	// Looping at every fps
	void FixedUpdate()
	{
 
		if (Input.GetKey (KeyCode.Escape))  // Checks if the escape key is pressed on windows or back button on mobile devices 
		{
			SceneManager.LoadScene ("Scenes/MainMenuScene"); // Load and displays the Main Menu scenes
		}

		if (isPlayerMovable)
		{
			if (Input.GetMouseButtonDown (0))  // Checks if the right mouse is pressed on windows or tap on mobile devices 
			{	 
				rigidBody.velocity = new Vector2 (0, up); // Set the velocity or speed of the player 
				rigidBody.gravityScale = gravity; // Set the gravity value for the player
			} 
		}

		 
	}


 

	public static void pausePlayer(bool pause){
 
		if (pause) 
		{
			rigidBody.gravityScale = 0.0f;  // Set gravity of the player to zero
			rigidBody.velocity = new Vector2 (0, 0); // Set the player velocity to 0
			 
		}  

		 isPlayerMovable = !pause;
	}


	 // Detects Inner Collision
 	void OnTriggerExit2D(Collider2D coll)
	{
		infiniteSceen_ui.updateScore(); // Update the score value 
		 
	}

	// Detects Outer Collision
	void OnCollisionEnter2D(Collision2D coll)
	{
		switch (coll.collider.name)
		{
		case "Rings(Clone)":
			coll.collider.transform.GetChild (2).gameObject.SetActive (false); // Deactivate the inner ring boundary
			break;
		case "enemy1(Clone)":
			SceneManager.LoadScene ("Scenes/MainMenuScene"); // Load main menu scene if enemies collide
			break;
		case "playing_background":
			SceneManager.LoadScene ("Scenes/MainMenuScene"); // Load main scene if border touches
			break;
		}
	
	 }

	 
}
