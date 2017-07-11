using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuTimeCounter : MonoBehaviour
{
	public Text memoryTimeText;
	public Text kinectTimeText;

	public static float memoryActiveTime;
	public static float kinectActiveTime;

	public int memorySceneIndex;
	public int kinectSceneIndex;
	public int mainMenuIndex;

	private bool hasShownText = false;

	private MainMenuTimeCounter thisTimeCounter;

	private void Awake ()
	{
		if (thisTimeCounter == null) {
			thisTimeCounter = this;
			DontDestroyOnLoad (this);
		}
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Scene activeScene = SceneManager.GetActiveScene ();

		if (activeScene.buildIndex == memorySceneIndex) {
			memoryActiveTime += Time.deltaTime;
		} else if (activeScene.buildIndex == kinectSceneIndex) {
			kinectActiveTime += Time.deltaTime;
		} else if (activeScene.buildIndex == mainMenuIndex && hasShownText == false) {
			memoryTimeText = GameObject.Find ("Timer_Memory").GetComponent<Text> ();
			kinectTimeText = GameObject.Find ("Timer_Kinect").GetComponent<Text> ();
			memoryTimeText.text = memoryActiveTime.ToString ();
			kinectTimeText.text = kinectActiveTime.ToString ();
			hasShownText = true;
		} else if (activeScene.buildIndex != mainMenuIndex) {
			hasShownText = false;
		}
	}
}
