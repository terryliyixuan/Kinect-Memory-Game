using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Use this script to display how many correct answers player has given
// Put this script on the "Correct Answer" text object

public class DisplayCorrectAnswerNumber : MonoBehaviour
{
	// ---------------------------
	// Private variables
	// ---------------------------
	// Declare a text type
	private Text myText;

	// Use this for initialization
	void Start ()
	{
		// Find the text component
		myText = GetComponent<Text> ();
		// Display the currentCorrectAnswer
		myText.text = QuestionBigManager.currentCorrectAnswer.ToString ();
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		// Display the "currentCorrectAnswer" from the "QuestionBigManager" class
		if (QuestionBigManager.hasGivenAnswer == true && QuestionBigManager.isAnswerCorrect == true) {
			myText.text = QuestionBigManager.currentCorrectAnswer.ToString ();
			QuestionBigManager.hasGivenAnswer = false;
			QuestionBigManager.hasCurrentGameEnded = true;
		}
	}
}
