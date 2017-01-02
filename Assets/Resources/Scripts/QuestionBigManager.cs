using UnityEngine;
using System.Collections;

public class QuestionBigManager : MonoBehaviour
{

	// ---------------------------
	// Public variables
	// ---------------------------
	// Delcare a public array that stores the preset questions
	[Multiline]
	[HideInInspector]
	public QuestionData[] questions;
	// Declare a ShapeBigManager
	private ShapeBigManager shapeManager;

	// Find all the "QuestionData" objects in the scene first by using Awake()
	void Awake ()
	{
		// Initialize the questions array
		questions = GameObject.FindObjectsOfType<QuestionData> ();
	}

	// Use this for initialization
	void Start ()
	{
		// Find the shapeManager in the scene
		shapeManager = GameObject.FindObjectOfType<ShapeBigManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
