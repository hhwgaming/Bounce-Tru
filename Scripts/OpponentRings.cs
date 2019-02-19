using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentRings : MonoBehaviour {

	// Variable Declaration
	[SerializeField] private GameObject opponents;
	[SerializeField] private GameObject enemy1;
	private int timerCounter = 0;
	private float ringSpeed = -3.0f;
	private static bool isOpponentMovable;
	private ArrayList allRings;
	private int maxTime = 1100, incrementer = 10; 


	//-----------------------------------------------------------------------------------------------------
	void Start () 
	{
		allRings = new ArrayList (); // Initialise the Array List Class to hold all rings produced
		create ();  // Create a new ball 
		isOpponentMovable = true; // set move the opponent to true
		maxTime = 1100;
	}
	//-------------------------------------------------------------------------------------------------------

	// Update is called once per frame
	void Update () 
	{
		timerCounter = timerCounter + incrementer; // Increase the time counter by 10 points

		if (timerCounter > maxTime) // Check if timer counter is more than maximum time
		{
 			if (Random.Range(1, 30) == 2)  // If the random number is 2, increase speed by 1
			{ 
				if (maxTime <= 800)
				{
					maxTime = 800;
				} else {
						maxTime = maxTime - 50; 
						ringSpeed = ringSpeed - 0.3f;
						incrementer = incrementer + 1;
						infiniteSceen_ui.rising_level (maxTime);
				        createExtraObject (enemy1); // Create random enemies when speed increase
					}
			 } 
				
			// Condition to check if balls are allowed to move.
			if (isOpponentMovable) { 
				 
				create ();  // Method to create new ball after every 1100 time tick
				foreach (GameObject balls in allRings) 
				{
					Rigidbody2D physics = balls.GetComponent<Rigidbody2D> ();
					physics.velocity = new Vector2 (ringSpeed, 0);
				}

			}
			timerCounter = 0; // set the time counter to 0, to repeat the process
		}  // End of if time counter is greater than 1100 time tick


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
		GameObject 	ring = (GameObject) Instantiate (opponents);  // Instiantiate New Ring
		if (Random.Range (-2, 10) == 0)
		{
			 ring.transform.eulerAngles = new Vector3 (0, 0, -50); // Rotate the ring by -50 degrees
		} else if (Random.Range (-2, 10) == 3) {
			 ring.transform.eulerAngles = new Vector3 (0, 0, -25); // Rotate the ring by -25 degrees
		}
		allRings.Add (ring); // Add new ring to the arraylist
		 
		ring.transform.position = new Vector2 (15, Random.Range (-2, 4)); // Set the position of the ring
		Rigidbody2D myRigidBody = ring.GetComponent<Rigidbody2D> (); // Get Reference to ring rigidbody
        myRigidBody.velocity  = new Vector2 (ringSpeed, 0); //  add velocity to make it start moving
	 
	}


	private void createExtraObject(GameObject object1)
	{
		GameObject anyEnemy = (GameObject)Instantiate (object1); // Instiantiate New Object
		anyEnemy.transform.position = new Vector2 (15, Random.Range (-2, 4));// Set the position of the object
		Rigidbody2D rigidbody2D = anyEnemy.GetComponent<Rigidbody2D> ();// Get Reference to object rigidbody
		rigidbody2D.velocity = new Vector2 (-4.0f, 0);//  add velocity to make it start moving

	}

 
	public static void pauseOpponent(bool pause){
		
		isOpponentMovable = !pause;

		 
	}



}
