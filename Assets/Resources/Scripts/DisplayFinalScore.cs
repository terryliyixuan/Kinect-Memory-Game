using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFinalScore : MonoBehaviour
{
	// ---------------------------
	// Private variables
	// ---------------------------
	// Declare a text type
	private Text myText;

	// Use this for initialization
	void Start ()
	{
		// Find the text
		myText = GetComponent<Text> ();
		// Display the final score
		myText.text = QuestionBigManager.currentCorrectAnswer.ToString ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
