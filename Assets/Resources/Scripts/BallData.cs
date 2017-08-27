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
		if (col.gameObject.tag == "Player" && QuestionBigManager.shouldInputDisabled == false) {
			// Set the "givenAnswer" as the number that this object contains/represents
			QuestionBigManager.givenAnswer = myNumber;
			DetermineAnswer ();
		}
	}

	void DetermineAnswer ()
	{
		// An answer has been given so set the "hasGivenAnswer" to be true
		QuestionBigManager.hasGivenAnswer = true;
		// Judge if the given answer is correct or not
		if (QuestionBigManager.givenAnswer == QuestionBigManager.theAnswer) {
			QuestionBigManager.isAnswerCorrect = true;
			Debug.Log ("The answer is correct");
		} else {
			QuestionBigManager.isAnswerCorrect = false;
			Debug.Log ("The answer is wrong");
		}
	}
}
