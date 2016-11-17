using UnityEngine;
using System.Collections;

public class Shape : MonoBehaviour
{

	// Data related to this game object
	public string myName;
	public string myShape;
	public Color myColor;

	// Declare components
	private Renderer myRenderer;

	// Use this for initialization
	void Start ()
	{
		// Set the name of this game object
		gameObject.name = myName;

		// Set the color of this game object
		myRenderer = GetComponent<Renderer> ();
		myRenderer.material.color = myColor;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
