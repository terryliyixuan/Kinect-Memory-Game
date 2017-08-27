using UnityEngine;
using System.Collections;

public class ShapeData : MonoBehaviour
{

	//----------------------------
	// Public variables
	// ---------------------------
	public string myShapeName;

	// ---------------------------
	// Private variables
	// ---------------------------
	private Color myColor;
	private Color myColorName;

	// Use this for initialization
	void Start ()
	{
		myColor = GetComponent<Renderer> ().material.color;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
