using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Use this script to switch the scene by touching the ball

public class TouchToSwitchScene : MonoBehaviour
{

	// ---------------------------
	// Public variables
	// ---------------------------
	// Declare the name of the next scene
	public string nextSceneName;

	// ---------------------------
	// Private variables
	// ---------------------------
	private bool hasSwitchedScene = false;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.S)) {
			SwitchScene ();
		}
	}

	void OnCollisionEnter (Collision col)
	{
		SwitchScene ();
	}

	void SwitchScene ()
	{
		if (hasSwitchedScene == false) {
			SceneManager.LoadScene (nextSceneName);
			hasSwitchedScene = true;
		}
	}
}
