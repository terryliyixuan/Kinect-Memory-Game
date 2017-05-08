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
	private SpriteRenderer mySpriteRenderer;

	// Use this for initialization
	void Start ()
	{
		Invoke ("AssignAttributes", 0.1f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (myInsSpot != null && myCurrentTarget != null && GameManager.isPlayerDead == false) {
			float distanceCovered = (Time.time - startTime) * myCurrentSpeed;
			float fractJourney = distanceCovered / journeyLength;
			transform.position = Vector3.Lerp (myInsSpot.position, myCurrentTarget.position, fractJourney);
			if (transform.position == myCurrentTarget.position) {
				Destroy (gameObject);
			}
		}
	}

	private void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player") {
			GameManager.isPlayerDead = true;
		}

	}

	private void AssignAttributes ()
	{
		mySpriteRenderer = GetComponent<SpriteRenderer> ();
		mySpriteRenderer.color = myColor;
		myCurrentSpeed = myInitialSpeed;
		myCurrentTarget = myInitialTarget;
		startTime = Time.time;
		journeyLength = Vector2.Distance (myInsSpot.position, myCurrentTarget.position);
	}
}
