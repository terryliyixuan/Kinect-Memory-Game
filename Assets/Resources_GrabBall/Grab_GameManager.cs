using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grab_GameManager : MonoBehaviour
{
	// Ball
	public GameObject ball;
	public GameObject[] ballPositions;
	private Grab_BallData[] availableBalls;

	// Timer
	public Image countDownTimerBar;
	public float barDepleteSpeed;

	// Score
	public Text scoreText;
	private int score;

	// Shapes
	public int minShapeNum;
	public int maxShapeNum;
	private int shapeNum;
	private bool hasANewShapeNum;

	// Cool Down
	private float CountDownTimer;
	public float CountDownTime;

	// Blink the camera
	public Color correctCameraColor;
	private Color defaultCameraColor;

	// Results
	public Camera camera_Results;
	public Text text_FinalScore;
	private bool hasShownResults = false;

	// Use this for initialization
	void Start ()
	{
		CountDownTimer = CountDownTime;
		defaultCameraColor = Camera.main.backgroundColor;
		camera_Results.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (DepleteTimerBar () == false) {
			if (hasANewShapeNum == false) {
				if (CoolDownBeforeSelectingANewNum () > 0) {
					CoolDownBeforeSelectingANewNum ();
					BlinkTheCamera ();
				} else {
					Camera.main.backgroundColor = defaultCameraColor;
					SelectANewNumber ();
					for (int i = 0; i < shapeNum; i++) {
						InstantiateShapes ();
					}
				}
			}
			if (CheckAvailableNum () == true && CoolDownBeforeSelectingANewNum () <= 0) {
				score++;
				DisplayScore ();
				hasANewShapeNum = false;
				CountDownTimer = CountDownTime;
			}
		} else if (hasShownResults == false) {
			ShowResults ();
			hasShownResults = true;
		}
	}

	private bool DepleteTimerBar ()
	{
		countDownTimerBar.fillAmount -= Time.deltaTime * barDepleteSpeed;
		if (countDownTimerBar.fillAmount <= 0) {
			return true;
		} else {
			return false;
		}
	}

	private void SelectANewNumber ()
	{
		if (minShapeNum >= maxShapeNum) {
			maxShapeNum = minShapeNum + 1;
		} else {
			shapeNum = (int)Random.Range (minShapeNum, maxShapeNum);
		}
		hasANewShapeNum = true;
	}

	private float CoolDownBeforeSelectingANewNum ()
	{
		CountDownTimer -= Time.deltaTime;
		return CountDownTimer;
	}

	private void InstantiateShapes ()
	{
		int rand = (int)Random.Range (0, ballPositions.Length);
		Instantiate (ball, ballPositions [rand].transform.position, Quaternion.identity);
	}

	private bool CheckAvailableNum ()
	{
		availableBalls = GameObject.FindObjectsOfType<Grab_BallData> ();
		if (availableBalls.Length == 0) {
			return true;
		} else {
			return false;
		}
	}

	private void DisplayScore ()
	{
		scoreText.text = score.ToString ();
	}

	private void BlinkTheCamera ()
	{
		Camera.main.backgroundColor = correctCameraColor;
	}

	private void ShowResults ()
	{
		Camera.main.gameObject.SetActive (false);
		camera_Results.gameObject.SetActive (true);
		text_FinalScore.text = score.ToString ();
	}
}
