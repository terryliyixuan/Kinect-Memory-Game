using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_BallData : MonoBehaviour
{
	public Color[] ballColors;
	private Color myColor;
	private string myColorName;
	private bool touchedByHand;
	private Transform touchingHand;


	// Use this for initialization
	void Start ()
	{
		int rand = (int)Random.Range (0, ballColors.Length);
		myColor = ballColors [rand];
		gameObject.GetComponent<SpriteRenderer> ().color = myColor;
		switch (rand) {
		case 0:
			myColorName = "Red";
			break;
		case 1:
			myColorName = "Blue";
			break;
		case 2:
			myColorName = "Green";
			break;
		case 3:
			myColorName = "Yellow";
			break;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (touchedByHand == true) {
			transform.position = touchingHand.transform.position;
		}
	}

	private void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Hand" && touchedByHand == false) {
			touchingHand = col.gameObject.transform;
			if (touchingHand.GetComponent<Grab_HandData> ().isAvailable == true) {
				touchingHand.GetComponent<Grab_HandData> ().isAvailable = false;
				touchedByHand = true;	
			}
		}

		if (col.gameObject.tag == "Basket" && touchedByHand == true) {
			if (myColorName == col.gameObject.GetComponent<Grab_BasketData> ().basketColorName) {
				touchingHand.GetComponent<Grab_HandData> ().isAvailable = true;
				Destroy (gameObject);
			}
		}
	}
}
