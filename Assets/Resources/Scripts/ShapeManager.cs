using UnityEngine;
using System.Collections;

public class ShapeManager : MonoBehaviour
{

	private Shape[] shapesInScene;

	// Use this for initialization
	void Start ()
	{
		shapesInScene = GameObject.FindObjectsOfType<Shape> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
