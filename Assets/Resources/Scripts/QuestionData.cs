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

public enum ShapeQuestions
{
	Circle,
	Penagon,
	Rect,
	Triangle
}

// This class stores all the data of a question object
public class QuestionData : MonoBehaviour
{
	// ---------------------------
	// Public variables
	// ---------------------------
	// Declare a bool that tells if this question
	public bool isThisAShapeQuestion = false;
	// Delcare a public array that stores the preset questions
	[Multiline]
	public string myQuestion;
	// Declare a dropdown from QuestionColor
	public ColorQuestions colorQuestions;
	// Declare a dropdown from ShapeQuestions
	public ShapeQuestions shapeQuestions;
	// Declare an int that receives the counter from shapeBigManager
	[HideInInspector]
	public int myAnswer;

	// ---------------------------
	// Private variables
	// ---------------------------
	// Declare a ShapeBigManager
	private ShapeBigManager shapeManager;

	// Use this for initialization
	void Start ()
	{
		// Initialize the "shapeManager"
		shapeManager = GameObject.FindObjectOfType<ShapeBigManager> ();

		if (isThisAShapeQuestion == false) {
			// Get the answer from the "ShapeBigManager" class
			GetColorAnswer ();
		} else {
			// Get the shape answer
			GetShapeAnswer ();
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void GetColorAnswer ()
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

	void GetShapeAnswer ()
	{
		switch (shapeQuestions) {
		case ShapeQuestions.Circle:
			myAnswer = shapeManager.totalCircleCounter;
			break;
		case ShapeQuestions.Penagon:
			myAnswer = shapeManager.totalPenagonCounter;
			break;
		case ShapeQuestions.Rect:
			myAnswer = shapeManager.totalRectCounter;
			break;
		case ShapeQuestions.Triangle:
			myAnswer = shapeManager.totalTriangleCounter;
			break;
		}
	}
}
