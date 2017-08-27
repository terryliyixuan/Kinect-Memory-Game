using UnityEngine;
using System.Collections;

// Declare an enum that helps determine which counter to get
public enum ColorQuestions
{
	None,
	Black,
	Red,
	Green,
	Blue,
	Yellow
}

public enum ShapeQuestions
{
	None,
	Circle,
	Penagon,
	Rect,
	Triangle
}

public enum QuestionTypes
{
	ShapeQuestion,
	ColorQuestion,
	TotalShapeQuestion,
	TotalColorQuestion
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
	// Declare a dropdown from ShapeQuestions
	public ShapeQuestions shapeQuestions;
	// Declare a dropdown from QuestionTypes
	public QuestionTypes questionTypes;
	// Declare an int that receives the counter from shapeBigManager
	//[HideInInspector]
	public int myAnswer;

	// ---------------------------
	// Private variables
	// ---------------------------
	// Declare a ShapeBigManager
	private ShapeBigManager shapeManager;

	void Awake ()
	{
		// Initialize the "shapeManager"
		shapeManager = GameObject.FindObjectOfType<ShapeBigManager> ();

		switch (questionTypes) {
		case QuestionTypes.ColorQuestion:
			GetColorAnswer ();
			break;
		case QuestionTypes.ShapeQuestion:
			GetShapeAnswer ();
			break;
		case QuestionTypes.TotalShapeQuestion:
			GetTotalShapeAnswer ();
			break;
		case QuestionTypes.TotalColorQuestion:
			GetTotalColorAnswer ();
			break;
		}
	}

	// Use this for initialization
	void Start ()
	{

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

	void GetTotalShapeAnswer ()
	{
		myAnswer = shapeManager.totalShapeCounter;
	}

	void GetTotalColorAnswer ()
	{
		myAnswer = shapeManager.totalColorCounter;
	}
}
