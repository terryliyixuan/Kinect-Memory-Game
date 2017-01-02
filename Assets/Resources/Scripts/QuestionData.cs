using UnityEngine;
using System.Collections;

// Declare an enum that helps determine which counter to get
public enum ColorQuestions
{
	Black,
	Red,
	Green,
	Blue,
	Yellow
}

// This class stores all the data of a question object
public class QuestionData : MonoBehaviour
{
	// ---------------------------
	// Public variables
	// ---------------------------
	// Delcare a public array that stores the preset questions
	[Multiline]
	public string myQuestion;
	// Declare a dropdown from QuestionColor
	public ColorQuestions colorQuestions;
	// Declare an int that receives the counter from shapeBigManager
	[HideInInspector]
	public int myAnswer;
	// Declare a ShapeBigManager
	private ShapeBigManager shapeManager;

	// Use this for initialization
	void Start ()
	{
		// Initialize the "shapeManager"
		shapeManager = GameObject.FindObjectOfType<ShapeBigManager> ();

		// Get the answer from the "ShapeBigManager" class
		GetAnswer ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void GetAnswer ()
	{
		switch (colorQuestions) {
		case ColorQuestions.Black:
			myAnswer = shapeManager.totalBlackCounter;
			break;
		case ColorQuestions.Blue:
			myAnswer = shapeManager.totalBlueCounter;
			break;
		case ColorQuestions.Green:
			myAnswer = shapeManager.totalGreenCounter;
			break;
		case ColorQuestions.Red:
			myAnswer = shapeManager.totalRedCounter;
			break;
		case ColorQuestions.Yellow:
			myAnswer = shapeManager.totalYellowCounter;
			break;
		}
	}
}
