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
	// Declare a bool that tells if touching this object should quit the game
	public bool isThisAQuitter = false;

	// ---------------------------
	// Private variables
	// ---------------------------
	private bool hasSwitchedScene = false;

	// Use this for initialization
	void Start ()
	{
		Screen.SetResolution (1920, 1080, true);
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.S)) {
			SwitchScene ();
		}

		// Quit the game quickly by pressing ESC
		if (Input.GetKeyDown (KeyCode.Escape) && isThisAQuitter == true) {
			Application.Quit ();		
		}
	}

	void OnCollisionEnter (Collision col)
	{
		if (isThisAQuitter == false) {
			SwitchScene ();
		} else {
			Application.Quit ();
		}

	}

	void SwitchScene ()
	{
		if (hasSwitchedScene == false) {
			SceneManager.LoadScene (nextSceneName);
			hasSwitchedScene = true;
		}
	}
}
