using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class QuestionBigManager : MonoBehaviour
{

	// ---------------------------
	// Public variables
	// ---------------------------
	// Delcare a public array that stores the preset questions
	[Multiline]
	[HideInInspector]
	public QuestionData[] questions;
	// Declare the name of the game scene
	public string gameSceneName;
	// Declare the name of the end scene
	public string endSceneName;
	// Declare a float that tells how long it should wait to switch back to the game scene
	public float switchSceneTime;
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
	// Declare an int that tells how many faulys player has made
	public static int currentFault = 0;
	// Declare an int tells how many correct answers player has given
	public static int currentCorrectAnswer = 0;
	// Declare a bool that tells if this current game has ended
	public static bool hasCurrentGameEnded = false;
	// Declare a bool that tells if player input shall be disabled
	public static bool shouldInputDisabled = false;
	// All potential questions including game objects that have question children
	public GameObject[] questionsArray;
	// Which type of question should we ask
	public static int questionTypeCounter = 0;

	// ---------------------------
	// Private variables
	// ---------------------------
	// Declare a float that counts the switchSceneTimer;
	private float switchSceneTimer;

	// Find all the "QuestionData" objects in the scene first by using Awake()
	void Awake ()
	{
		// Initialize the questions array
		//questions = GameObject.FindObjectsOfType<QuestionData> ();
		GenerateAQuestion ();
	}

	// Use this for initialization
	void Start ()
	{
		// Reset the bools
		hasGivenAnswer = false;
		isAnswerCorrect = false;
		hasCurrentGameEnded = false;
		shouldInputDisabled = false;

		// Find the shapeManager in the scene
		shapeManager = GameObject.FindObjectOfType<ShapeBigManager> ();
		// Randomize a question number
		questionNum = (int)Random.Range (0, questions.Length);
		// Find answer to the question
		theAnswer = questions [questionNum].myAnswer;
		// Set the switchTimer
		switchSceneTimer = switchSceneTime;
	}

	// Update is called once per frame
	void Update ()
	{
		if (hasGivenAnswer == true && isAnswerCorrect == false) {
			shouldInputDisabled = true;
			currentFault++;
		} else if (hasGivenAnswer == true && isAnswerCorrect == true) {
			shouldInputDisabled = true;
			currentCorrectAnswer++;
		}


		// Before switching back to the game scene, count down to trans
		if (hasCurrentGameEnded == true) {
			switchSceneTimer -= Time.deltaTime;
			if (switchSceneTimer <= 0) {
				hasCurrentGameEnded = false;

				// Destroy the Shape Manager that has a "DontDestroyOnLoad()"
				Destroy (shapeManager.gameObject);

				// Switch to result screen when player fails for 3 times
				// Or switch back to game scene if not failed for the 3rd time
				if (questionTypeCounter < questionsArray.Length - 1) {
					if (currentFault == 3) {
						DisplayHeadsUpText.headsUpTextCounter++;
						SceneManager.LoadScene (gameSceneName);
					} else {
						SceneManager.LoadScene (gameSceneName);
					}
				} else {
					if (currentFault == 3) {
						SceneManager.LoadScene (endSceneName);
					} else {
						SceneManager.LoadScene (gameSceneName);
					}
				}
			}
		}
	}

	// Get a question from the current question type
	private void GenerateAQuestion ()
	{
		// When players fails for three times, we generate question from the next question type
		if (currentFault == 3) {
			questionTypeCounter++;
			currentFault = 0;
		}
		questions = questionsArray [questionTypeCounter].GetComponentsInChildren<QuestionData> ();
	}
}
