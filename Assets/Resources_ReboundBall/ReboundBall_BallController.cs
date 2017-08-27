using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReboundBall_BallController : MonoBehaviour
{
	[HideInInspector]public Transform myInsSpot;
	[HideInInspector]public Transform myTargetSpot;

	// Travel
	private float journeyLength;
	private float startTime;

	// Speed
	public float maxSpeed;
	public float minSpeed;
	private float mySpeed;

	// Color
	private string myColor;
	public Color[] colors;

	// Use this for initialization
	void Start ()
	{
		journeyLength = Vector2.Distance (myInsSpot.position, myTargetSpot.position);
		startTime = Time.time;
		mySpeed = Random.Range (minSpeed, maxSpeed);
		AssignColor ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Movement ();
	}

	private void Movement ()
	{
		float distanceCovered = (Time.time - startTime) * mySpeed;
		float fractJourney = distanceCovered / journeyLength;
		transform.position = Vector3.Lerp (myInsSpot.position, myTargetSpot.position, fractJourney);
		if (transform.position == myTargetSpot.position) {
			Destroy (gameObject);
		}
	}

	private void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player") {
			if (myColor == col.gameObject.GetComponent<ReboundBall_BodyPartData> ().myColor) {
				ReboundBall_GameManager.score++;
				Destroy (gameObject);	
			}
		}
	}

	private void AssignColor ()
	{
		int rand = (int)Random.Range (0, colors.Length);
		gameObject.GetComponent<SpriteRenderer> ().color = colors [rand];
		switch (rand) {
		case 0:
			myColor = "Red";
			break;
		case 1:
			myColor = "Blue";
			break;
		case 2:
			myColor = "Green";
			break;
		case 3:
			myColor = "Yellow";
			break;
		case 4:
			myColor = "Black";
			break;
		}
	}
}
