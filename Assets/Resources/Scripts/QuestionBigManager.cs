using UnityEngine;
using System.Collections;

public class QuestionBigManager : MonoBehaviour
{

	// ---------------------------
	// Public variables
	// ---------------------------
	// Delcare a public array that stores the preset questions
	[Multiline]
	[HideInInspector]
	public QuestionData[] questions;
	// Declare a ShapeBigManager
	private ShapeBigManager shapeManager;
	// Declare a question that is to be selected
	public static int questionNum;
	// Declare a int that receives the answer to the question randomized
	public static int theAnswer;
	// Declare a int that receives the answer that player gives
	public static int givenAnswer;
	// Declare a bool that tells if an answer has been given or not
	public static bool hasGivenAnswer = false;
	// Declare a bool that determines if the answer given by the player is correct or not
	public static bool isAnswerCorrect = false;
	// Declare an int that tells what fault is this
	public static int currentFault = 0;


	// Find all the "QuestionData" objects in the scene first by using Awake()
	void Awake ()
	{
		// Initialize the questions array
		questions = GameObject.FindObjectsOfType<QuestionData> ();
	}

	// Use this for initialization
	void Start ()
	{
		// Find the shapeManager in the scene
		shapeManager = GameObject.FindObjectOfType<ShapeBigManager> ();
		// Randomize a question number
		questionNum = (int)Random.Range (0, questions.Length);
		// Find answer to the question
		theAnswer = questions [questionNum].myAnswer;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (hasGivenAnswer == true && isAnswerCorrect == false) {
			currentFault++;
		}
	}
}
