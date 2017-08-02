using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_MaintainBody : MonoBehaviour
{

	public GameObject[] targets;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void RemoveAt<T> (ref T[] arr, int index)
	{
		for (int a = index; a < arr.Length - 1; a++) {
			arr [a] = arr [a + 1];
		}

	}
}
