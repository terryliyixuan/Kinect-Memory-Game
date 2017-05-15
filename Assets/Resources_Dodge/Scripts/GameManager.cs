using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	// ---------------------------
	// Public variables
	// ---------------------------
	public Text timerText;

	[Header ("Beginning Variables")]
	public string startText;
	public float startTextTime;
	public int startCountDownTime;
	[Header ("Ending Variables")]
	public string endText;
	public Camera scoreCamera;
	public Text scoreText;
	public float endCDTime;
	public TouchToSwitchScene endCircle;
	//public GameObject scoreBody;


	public static bool isPlayerDead = false;
	public static bool hasGameStarted;
	// ---------------------------
	// Private variables
	// ---------------------------
	private float currentTime;
	private int startCountDownTimer = 0;
	private int startNumber;


	// Use this for initialization
	void Start ()
	{
		isPlayerDead = false;
		startNumber = startCountDownTime;
	}
		
	// Update is called once per frame
	void Update ()
	{
		// Before game starts
		// Display title text
		if (hasGameStarted == false) {
			if (startTextTime > 0) {
				timerText.text = startText;
				timerText.fontSize = 100;
				startTextTime -= Time.deltaTime;
			}
			// Before game starts
			// Display count down text
			else {
				if ((Time.timeSinceLevelLoad - 3) >= startCountDownTimer && startCountDownTimer <= startCountDownTime) {
					timerText.fontSize = 250;
					startNumber -= 1;
					timerText.text = startNumber.ToString ();
					startCountDownTimer += 1;
				}

				if (startCountDownTimer == startCountDownTime) {
					timerText.text = null;
					hasGameStarted = true;
				}
			}
		}

		// Game starts
		// Display time
		else {
			if (isPlayerDead == false) {
				currentTime += Time.deltaTime;
				timerText.text = currentTime.ToString ("f0");
				scoreText.text = timerText.text;
			} 
			// Game ends
			// Display ending text
			else {
				timerText.text = endText;
				if (endCDTime > 0) {
					endCDTime -= Time.deltaTime;
				} else {
					DartController[] darts = GameObject.FindObjectsOfType<DartController> ();
					foreach (DartController dart in darts) {
						dart.gameObject.SetActive (false);
					}
					Camera.main.gameObject.SetActive (false);
					scoreCamera.gameObject.SetActive (true);
					endCircle.gameObject.SetActive (true);
					//scoreBody.gameObject.SetActive (true);
					Destroy (gameObject);
				}
			}
		}
	}
}
