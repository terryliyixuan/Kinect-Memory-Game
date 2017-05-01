using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartController : MonoBehaviour
{
	// ---------------------------
	// Public variables
	// ---------------------------
	public float myInitialSpeed;
	[HideInInspector]public Color myColor;
	public Transform myInitialTarget;
	[HideInInspector]public Transform myInsSpot;

	// ---------------------------
	// Private variables
	// ---------------------------
	private float myCurrentSpeed;
	private Transform myCurrentTarget;
	private float startTime;
	private float journeyLength;

	// Use this for initialization
	void Start ()
	{
		myCurrentSpeed = myInitialSpeed;
		myCurrentTarget = myInitialTarget;
		startTime = Time.time;
		journeyLength = Vector2.Distance (myInsSpot.position, myCurrentTarget.position);
	}
	
	// Update is called once per frame
	void Update ()
	{
		float distanceCovered = (Time.time - startTime) * myCurrentSpeed;
		float fractJourney = distanceCovered / journeyLength;
		transform.position = Vector3.Lerp (myInsSpot.position, myCurrentTarget.position, fractJourney);
	}
}
