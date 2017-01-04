using UnityEngine;
using System.Collections;

public class BallData : MonoBehaviour
{
	// ---------------------------
	// Public variables
	// ---------------------------
	// Declare the number this ball represents
	public int myNumber;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "Player") {
			QuestionBigManager.givenAnswer = myNumber;
			DetermineAnswer ();
		}
	}

	void DetermineAnswer ()
	{
		if (QuestionBigManager.givenAnswer == QuestionBigManager.theAnswer) {
			Debug.Log ("The answer is correct");
		} else {
			Debug.Log ("The answer is wrong");
		}
	}
}
