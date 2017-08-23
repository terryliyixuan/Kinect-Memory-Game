using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReboundBall_GameManager : MonoBehaviour
{
	public GameObject ball;
	public Transform[] spotsRow1;
	public Transform[] spotsRow2;

	public float coolDownTime;
	private float coolDownTimer;

	// Count down
	public float barDepleteSpeed;
	public Image countDownTimerBar;

	// Score
	public static int score;
	public Text scoreText;

	// Results
	public Camera camera_Results;
	public Text text_FinalScore;

	// Use this for initialization
	void Start ()
	{
		coolDownTimer = coolDownTime;
		camera_Results.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		DisplayScore ();
		if (DepleteTimerBar () == false) {
			coolDownTimer -= Time.deltaTime;
			if (coolDownTimer <= 0) {
				InstantiateShape ();
				coolDownTimer = coolDownTime;
			}	
		} else {
			ShowResults ();
		}
	}

	private void InstantiateShape ()
	{
		Transform insSpot;
		Transform targetSpot;

		// Find an ins and target spot
		float rand = Random.Range (0, 1);
		if (rand <= 0.5) {
			insSpot = spotsRow1 [(int)Random.Range (0, spotsRow1.Length - 1)];
			targetSpot = spotsRow2 [(int)Random.Range (0, spotsRow2.Length - 1)];
		} else {
			insSpot = spotsRow2 [(int)Random.Range (0, spotsRow2.Length - 1)];
			targetSpot = spotsRow1 [(int)Random.Range (0, spotsRow1.Length - 1)];
		}

		GameObject ballInstantiated = Instantiate (ball, insSpot.transform.position, Quaternion.identity)as GameObject;
		ballInstantiated.GetComponent<ReboundBall_BallController> ().myInsSpot = insSpot;
		ballInstantiated.GetComponent<ReboundBall_BallController> ().myTargetSpot = targetSpot;
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

	private void DisplayScore ()
	{
		scoreText.text = score.ToString ();
	}

	private void ShowResults ()
	{
		Camera.main.gameObject.SetActive (false);
		camera_Results.gameObject.SetActive (true);
		text_FinalScore.text = score.ToString ();
	}
}
