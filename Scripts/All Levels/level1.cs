using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1 : MonoBehaviour {


	[SerializeField] private GameObject opponent;
	[SerializeField] private GameObject endpoint;
	private ArrayList allRings;
	private float ringSpeed = -4.0f;
	private int timerCounter = 0;
	private int maxTime = 1100, incrementStep = 10; 
	private static bool isOpponentMovable;
	private int gameOvertimer, gameOverIncrement;

	//---------------------------------------------------------------------------------------------------------
	void Start () 
	{
		allRings = new ArrayList (); // Initialise the Array List Class to hold all rings produced
		isOpponentMovable = false;
		timerCounter = maxTime - 200;
	}


	//---------------------------------------------------------------------------------------------------------
	// Update is called once per frame
	void Update () {

		if (isOpponentMovable) 
		{
			timerCounter = timerCounter + incrementStep; // Increase the time counter by 10 points
			gameOvertimer = gameOvertimer + gameOverIncrement; // Increase the game time counter by 10 points

			if (timerCounter > maxTime) // Check if timer counter is more than maximum time
			{
				if (allRings.Count < 5) // Check if all rings count is less than 5
				{
					create (); // Create A New Ring
					foreach (GameObject balls in allRings) 
					{
						Rigidbody2D physics = balls.GetComponent<Rigidbody2D> ();
						physics.velocity = new Vector2 (ringSpeed, 0);
					}
				}
		
				timerCounter = 0; // set the time counter to 0, to repeat the process

			}// End of if time counter is greater than 1500 time tick

			if (allRings.Count == 5 && timerCounter > 1000) {
				createEndPoint (); // Create the end point barrier 
				gameOverIncrement = 10;
			}

			if (gameOvertimer > 1800) {
				level1_ui.showCompletionBanner ();
				gameOvertimer = 0;
			}
		}

		// Condition to check if rings are not allowed to move.
		if (!isOpponentMovable) {  
			foreach (GameObject items in allRings) {
				Rigidbody2D physics = items.GetComponent<Rigidbody2D> ();
				physics.velocity = new Vector2 (0, 0);
			}
		} 
	}


	//---------------------------------------------------------------------------------------------------------


	// Creating or Instantiating New Object
	private void create()
	{
		GameObject 	ring = (GameObject) Instantiate (opponent);  // Instiantiate New Ring
		allRings.Add (ring); // Add new ring to the arraylist
		ring.transform.position = new Vector2 (10, Random.Range (-2, 4)); // Set the position of the ring
		Rigidbody2D myRigidBody = ring.GetComponent<Rigidbody2D> (); // Get Reference to ring rigidbody
		myRigidBody.velocity  = new Vector2 (ringSpeed, 0); //  add velocity to make it start moving

	}


	private void createEndPoint()
	{
		GameObject 	point = (GameObject) Instantiate (endpoint);  // Instiantiate New Ring
		allRings.Add (point); // Add new ring to the arraylist
		point.transform.position = new Vector2 (10,0); // Set the position of the ring
		Rigidbody2D myRigidBody = point.GetComponent<Rigidbody2D> (); // Get Reference to ring rigidbody
		myRigidBody.velocity  = new Vector2 (ringSpeed, 0); //  add velocity to make it start moving
	
	
	}



	public static void pauseOpponent(bool value)
	{
		isOpponentMovable = !value;

	}
}
