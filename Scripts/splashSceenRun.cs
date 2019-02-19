using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class splashSceenRun : MonoBehaviour {
	 
	//Declaration
	public Slider slider;  // The Loading Slider
	public Text loadingText; // The Text to show the loading percentage
	private float timerCounter = 0.0f;
	private float incrementer = 10.0f;
	private float stoppingPoint = 500.0f;
	// Looping at every fps
	 void Update () {

		timerCounter = timerCounter + incrementer; // Increase the time counter by 10 points

		if (timerCounter > stoppingPoint)   //Check if the time counter if greater than the stopping point i.e. 500
		{ 
			    slider.value = slider.value + 0.1f;  // Set the value of the slider to the increase factor
			    loadingText.text = "Loading " + Mathf.Floor(slider.value * 100) + " % " ; // Set the current slider value to the text
			  
				if (slider.value >= 1.0f) // Check if the the slider value is more than 1
				{
				    loadingText.text = "Done " + Mathf.Floor(slider.value * 100) + " % " ; // Set the current slider value to the text
					StartCoroutine (keepProgressBar ()); // Wait for some time
				 }
				timerCounter = 0.0f; // Set the time counter back to zero to repeat the cycle
		}  
		 
		 
	}


	// Delay the Code in the block for some time
	private IEnumerator keepProgressBar ()
	{
		yield return new WaitForSeconds(3); // Wait for about 3 seconds
		SceneManager.LoadScene (1); // Load and display the first scene which is the main menu scene
	} 

}
