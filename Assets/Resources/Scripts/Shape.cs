using UnityEngine;
using System.Collections;

public class Shape : MonoBehaviour
{

	// Declare data related to this game object
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

		// Add 1 to "totalShapes" in ShapeManager
		ShapeManager.totalShapes++;

		// Add 1 to each shape category
		AddMyShape ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	// Add this shape to its category
	void AddMyShape ()
	{
		switch (myShape) {
		case "Rect":
			ShapeManager.totalRects++;
			break;
		case "Sphere":
			ShapeManager.totalSpheres++;
			break;
		case "Tri":
			ShapeManager.totalTris++;
			break;
		}
	}
}
