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

		// Declare a random int within questions array's length
		// And display the question on this text object
		int rand = (int)Random.Range (0, questionManager.questions.Length);
		myText.text = questionManager.questions [rand].myQuestion;

		Debug.Log ("The answer is: " + questionManager.questions [rand].myAnswer);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
