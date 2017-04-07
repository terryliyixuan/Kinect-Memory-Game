using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHeadsUpText : MonoBehaviour
{
	// ---------------------------
	// Public variables
	// ---------------------------
	public float displayTime;
	// How long this headsup should be displayed
	[Multiline]
	public string[] headsUpTexts;
	// Which text should be displayed now
	public static int headsUpTextCounter = 0;

	// ---------------------------
	// Private variables
	// ---------------------------
	// The text component
	private Text myText;

	// Use this for initialization
	void Start ()
	{
		myText = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update ()
	{
		DisplayHeadsUp ();
	}

	private void DisplayHeadsUp ()
	{
		// When player hasn't given any correct/wrong answer, meaning the game just starts for the first time...
		// ...we display the first text
		if (QuestionBigManager.currentCorrectAnswer == 0 && QuestionBigManager.currentFault == 0) {
			myText.text = headsUpTexts [headsUpTextCounter];
		} else {
			// When the player fails for 3 times, meaning a new type of question is generated...
			// ...we display the headsup text for once
			if (QuestionBigManager.currentFault == 3) {
				myText.text = headsUpTexts [headsUpTextCounter];
			} else {
				myText.text = null;
			}
		}


		// We set the text to null when display time is passed
		displayTime -= Time.deltaTime;
		if (displayTime <= 0) {
			myText.text = null;
		}
	}
}
