using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager_MaintainBody : MonoBehaviour
{
	// Target positions
	private GameObject[] targets;
	public GameObject shapeToInstantiate;

	// How many shapes to instantiate
	private int shapeAmount;
	private int shapeAmountCounter = 0;
	public int minNum;
	public int maxNum;
	private GameObject[] availableShapesToTouch;
	public static int touchedShapeCounter = 0;
	private bool allShapesAreTouched;

	// Color indicator
	public Color correctCameraColor;
	public Color wrongCameraColor;
	private Camera mainCamera;

	// Count down timer when balancing
	public float countDownStartTime;
	[HideInInspector]public float countDownTimer;

	// Texts
	public Text timerText;
	public Text scoreText;
	private int score = 0;

	// Count down timer bar
	public Image countDownTimerBar;
	public float barDepleteSpeed;
	private bool timeIsOver;

	// End results
	public Camera camera_Results;
	public Text text_FinalScore;
	private bool hasShownResults = false;


	// Use this for initialization
	void Start ()
	{
		// Find all the target position objects
		targets = GameObject.FindGameObjectsWithTag ("Maintain_TargetPosition");
		shapeAmount = Random.Range (minNum, maxNum);
		mainCamera = Camera.main;
		wrongCameraColor = Camera.main.backgroundColor;
		touchedShapeCounter = 0;
		camera_Results.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		DepleteTimerBar ();

		if (timeIsOver == false) {
			if (shapeAmountCounter < shapeAmount) {
				SelectATarget ();
				shapeAmountCounter++;
			} else {
				DetermineTouchResults ();
			}
		} else if (hasShownResults == false) {
			ShowResults ();
			hasShownResults = true;
		}
	}

	private void SelectATarget ()
	{
		int rand = (int)Random.Range (0, targets.Length - 1);
		// Instantiate a target at a random target position
		Instantiate (shapeToInstantiate, targets [rand].transform.position, targets [rand].transform.rotation);
	}

	private void DetermineTouchResults ()
	{
		//timerText.text = countDownTimer.ToString ("F1");

		if (touchedShapeCounter == (shapeAmount)) {
			allShapesAreTouched = true;
		} else {
			allShapesAreTouched = false;
		}

		if (allShapesAreTouched == true) {
			mainCamera.backgroundColor = correctCameraColor;
			countDownTimer -= Time.deltaTime;
		} else {
			mainCamera.backgroundColor = wrongCameraColor;
			//countDownTimer = countDownStartTime;
		}

		// If the player successfully maintains the position after the required time...
		if (countDownTimer < 0) {
			// Reset all timers and counters
			score++;
			scoreText.text = score.ToString ();
			shapeAmountCounter = 0;
			shapeAmount = Random.Range (minNum, maxNum); 
			countDownTimer = countDownStartTime;
			touchedShapeCounter = 0;
			//RemoveOldTargets ();
		}
	}

	private void RemoveOldTargets ()
	{
		foreach (GameObject oldTarget in availableShapesToTouch) {
			Destroy (oldTarget.gameObject);
		}
	}

	private void DepleteTimerBar ()
	{
		countDownTimerBar.fillAmount -= Time.deltaTime * barDepleteSpeed;
		if (countDownTimerBar.fillAmount <= 0) {
			timeIsOver = true;
		}
	}

	private void ShowResults ()
	{
		Camera.main.gameObject.SetActive (false);
		camera_Results.gameObject.SetActive (true);
		text_FinalScore.text = score.ToString ();
	}
}
