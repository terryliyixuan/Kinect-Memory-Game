using UnityEngine;
using System.Collections;

public class ShapeBigManager : MonoBehaviour
{

	// ---------------------------
	// Public variables
	// ---------------------------
	public int minNum = 1;
	public int maxNum = 2;
	public GameObject[] shapePrefabs;
	public Color[] presetColors;
	public static int totalShapeCounter = 0;
	public static int totalColorCounter = 0;

	// ---------------------------
	// Private variables
	// ---------------------------
	private GameObject shapeInstantiated;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void InstantiateShape (int _num, Vector3 _pos)
	{
		shapeInstantiated = Instantiate (shapePrefabs [_num], _pos, Quaternion.identity) as GameObject;
		shapeInstantiated.transform.parent = GameObject.Find ("Shapes").transform;
	}

	void AssignColor ()
	{
		int rand = (int)Random.Range (0, presetColors.Length - 1);

	}
}
