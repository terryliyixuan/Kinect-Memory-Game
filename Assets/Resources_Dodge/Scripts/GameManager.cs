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
		if (hasGameStarted == false) {
			if (startTextTime > 0) {
				timerText.text = startText;
				timerText.fontSize = 100;
				startTextTime -= Time.deltaTime;
			} else {
				if ((Time.timeSinceLevelLoad - 3) >= startCountDownTimer && startCountDownTimer <= startCountDownTime) {
					Debug.Log ("counting down cd time");
					startNumber -= 1;
					timerText.text = startNumber.ToString ();
					startCountDownTimer += 1;
				}

				if (startCountDownTimer == startCountDownTime) {
					timerText.text = null;
					hasGameStarted = true;
				}
			}
		} else {
			if (isPlayerDead == false) {
				currentTime += Time.deltaTime;
				timerText.text = currentTime.ToString ("f0");
			} else {
				timerText.text = endText;
			}
		}
	}
}
