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
	public string startText;
	public string endText;
	public static bool isPlayerDead = false;

	// ---------------------------
	// Private variables
	// ---------------------------
	private float currentTime;
	private bool hasGameStarted;


	// Use this for initialization
	void Start ()
	{
		isPlayerDead = false;

	}
		
	// Update is called once per frame
	void Update ()
	{
		if (isPlayerDead == false) {
			currentTime += Time.deltaTime;
			timerText.text = currentTime.ToString ("f0");
		} else {
			timerText.text = endText;
		}
	}
}
