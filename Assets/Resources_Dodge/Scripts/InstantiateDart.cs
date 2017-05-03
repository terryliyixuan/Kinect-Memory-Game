using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateDart : MonoBehaviour
{
	// ---------------------------
	// Public variables
	// ---------------------------
	public Color[] presetColors;
	public GameObject[] instanceSpots;
	public GameObject[] targetSpots;
	public DartController[] dartPrefabs;
	public float maxSpeed;
	public float minSpeed;
	public float insGapTime;
	
	// ---------------------------
	// Private variables
	// ---------------------------
	private float insGapTimer;

	// Use this for initialization
	void Start ()
	{
		insGapTime = insGapTime;
	}
	
	// Update is called once per frame
	void Update ()
	{
		insGapTimer -= Time.deltaTime;
		if (insGapTimer <= 0) {
			int randDart = (int)Random.Range (0, dartPrefabs.Length - 1);
			int randInsSpot = (int)Random.Range (0, instanceSpots.Length - 1);
			int randInitialSpeed = (int)Random.Range (minSpeed, maxSpeed);
			int randInitialTarget = (int)Random.Range (0, targetSpots.Length - 1);
			int randColor = (int)Random.Range (0, presetColors.Length - 1);
			DartController newDart = Instantiate (dartPrefabs [randDart], instanceSpots [randInsSpot].transform.position, Quaternion.identity) as DartController;
			newDart.myColor = presetColors [randColor];
			newDart.myInitialSpeed = randInitialSpeed;
			newDart.myInsSpot = instanceSpots [randInsSpot].transform;
			newDart.myInitialTarget = targetSpots [randInitialTarget].transform;
			insGapTimer = insGapTime;
		}
	}
}
