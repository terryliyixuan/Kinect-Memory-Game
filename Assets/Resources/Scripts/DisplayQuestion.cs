using UnityEngine;
using UnityEngine.UI;
using System.Collections;


// This class handles displaying questions preset in the "QuestionBigManager"
public class DisplayQuestion : MonoBehaviour
{
	// ---------------------------
	// Private variables
	// ---------------------------
	// Declare a questionManager
	private QuestionBigManager questionManager;

	// Declare a text
	private Text myText;


	// Use this for initialization
	void Start ()
	{
		// Instantiate the questionManager
		questionManager = GameObject.FindObjectOfType<QuestionBigManager> ();
		// Instantiate myText
		myText = GetComponent<Text> ();
		// Display the question on this text object
		myText.text = questionManager.questions [QuestionBigManager.questionNum].myQuestion;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
