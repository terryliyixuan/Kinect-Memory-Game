using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaintainBody_TargetData : MonoBehaviour
{

	public bool iAMTouched = false;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player" && iAMTouched == false) {
			iAMTouched = true;
			GameManager_MaintainBody.touchedShapeCounter++;
			Destroy (gameObject);
		}
	}

	/*
	private void OnTriggerExit (Collider col)
	{
		if (col.gameObject.tag == "Player") {
			iAMTouched = false;
			GameManager_MaintainBody.touchedShapeCounter--;
		}
	}
	*/
}
