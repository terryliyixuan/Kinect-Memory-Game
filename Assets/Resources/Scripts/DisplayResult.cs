using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayResult : MonoBehaviour
{
	// ---------------------------
	// Private variables
	// ---------------------------
	private Text myText;

	// Use this for initialization
	void Start ()
	{
		// Grab the text component of this text
		myText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
