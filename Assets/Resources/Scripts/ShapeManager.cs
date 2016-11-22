using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShapeManager : MonoBehaviour
{
	// Declare a counter for shapes
	public static int totalShapes;
	public static int totalRects;
	public static int totalSpheres;
	public static int totalTris;

	// Declare the name of the next scene
	public string nextSceneName;

	// Don't destroy this manager, I need the data for the next scene!
	void Awake ()
	{
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start ()
	{
		totalShapes = 0;
		totalRects = 0;
		totalSpheres = 0;
		totalTris = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Debug data info
		if (Input.GetKeyDown (KeyCode.D)) {
			Debug.Log ("total shapes: " + totalShapes);
			Debug.Log ("total rectangles: " + totalRects);
			Debug.Log ("total spheres: " + totalSpheres);
			Debug.Log ("total triangles: " + totalTris);
		}
		// Switch scene
		if (Input.GetKeyDown (KeyCode.Space)) {
			SceneManager.GetSceneByName (nextSceneName);
		}
	}
}
