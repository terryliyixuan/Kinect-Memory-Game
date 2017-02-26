using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class DisplayImageResults : MonoBehaviour
{
	// ---------------------------
	// Public variables
	// ---------------------------
	// Declare sprites for right and wrong answers
	public Sprite correctSprite;
	public Sprite wrongSprite;


	// ---------------------------
	// Private variables
	// ---------------------------
	// Declare the Image component
	private Image[] images;


	// Use this for initialization
	void Start ()
	{
		images = GetComponentsInChildren<Image> ();
		images = images.OrderBy (p => p.name).ToArray ();
		for (int i = 0; i < QuestionBigManager.currentFault; i++) {
			images [i].sprite = wrongSprite;
		}
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		if (QuestionBigManager.hasGivenAnswer == true && QuestionBigManager.isAnswerCorrect == false) {
			Debug.Log ("currentfault is: " + QuestionBigManager.currentFault);
			images [QuestionBigManager.currentFault - 1].sprite = wrongSprite;
			QuestionBigManager.hasGivenAnswer = false;
			QuestionBigManager.hasCurrentGameEnded = true;
		}
	}
}
