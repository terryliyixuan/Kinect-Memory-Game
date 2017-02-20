using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Use this script to count down 3 seconds to start the game

public class CountDownToStart : MonoBehaviour
{
	// ---------------------------
	// Public variables
	// ---------------------------
	// Declares what the count down time is
	public int cdTime = 3;

	// ---------------------------
	// Private variables
	// ---------------------------
	// Declare the text component
	private Text myText;

	// Declare an int that acts as the number on the screen
	private int startNumber;

	// Declare an int that calculates what time it is now
	private int cdTimer;

	// Declare a bool that tells if the count down is over
	public static bool isCountDownOver = false;

	void Awake()
	{
		StartCoroutine (WaitForABit());
	}

	// Use this for initialization
	void Start ()
	{
		myText = GetComponent<Text> ();
		myText.text = startNumber.ToString ();
		startNumber = cdTime;
		cdTimer = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isCountDownOver == false) {
			if (Time.time >= cdTimer && cdTimer <= cdTime) {
				startNumber -= 1;
				myText.text = startNumber.ToString ();
				cdTimer += 1;
			}
		}

		if (cdTimer == cdTime) {
			myText.text = null;
			isCountDownOver = true;
		}
	}

	IEnumerator WaitForABit ()
	{
		yield return new WaitForSeconds (1);
	}
}
