using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayResult : MonoBehaviour
{
	// ---------------------------
	// Public variables
	// ---------------------------
	[Multiline]
	// Declare a public string that presets the text of correct input
	public string correctText;
	[Multiline]
	// Declare a public string that presets the text of wrong input
	public string wrongText;

	// ---------------------------
	// Private variables
	// ---------------------------
	private Text myText;

	// Use this for initialization
	void Start ()
	{
		// Grab the text component of this text
		myText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (QuestionBigManager.hasGivenAnswer == true) {
			if (QuestionBigManager.isAnswerCorrect == true) {
				myText.text = correctText;
			} else {
				myText.text = wrongText;
			}
		}	
	}
}
