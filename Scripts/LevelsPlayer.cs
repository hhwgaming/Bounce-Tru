using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelsPlayer : MonoBehaviour
{
	// Variable Declaration
	private static bool isPlayerMovable;
	private static Rigidbody2D  rigidBody;
	public float gravity = 0.5f;
	public float up = 6f;

	// Use this for initialization
	void Start ()
	{
		rigidBody = GetComponent<Rigidbody2D> (); // Get the rigid body of the player
		rigidBody.gravityScale = gravity; // Set the gravity value for the player
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
			
		if (isPlayerMovable)   // Check if ball can move
		{
			rigidBody.gravityScale = gravity; // Set the gravity value for the player
			if (Input.GetMouseButtonDown (0)) // Checks if the right mouse is pressed on windows or tap on mobile devices 
			{
				rigidBody.velocity = new Vector2 (0, up); // Set the velocity or speed of the player 
			} 
		} else { 
 
			rigidBody.gravityScale = 0.0f; // Set the gravity value for the player
			rigidBody.velocity = new Vector2 (0, 0); // Set the velocity or speed of the player 
		}
	}



	public static void pausePlayer(bool value)
	{
		isPlayerMovable = !value; //Assign a boolean value to player movement
	}


	// Detects Inner Collision
	void OnTriggerExit2D(Collider2D coll)
	{
		level1_ui.updateScores ();
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

