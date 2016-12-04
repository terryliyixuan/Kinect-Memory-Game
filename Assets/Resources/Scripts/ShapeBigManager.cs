using UnityEngine;
using System.Collections;

public class ShapeBigManager : MonoBehaviour
{

	// ---------------------------
	// Public variables
	// ---------------------------
	public int minNum = 1;
	public int maxNum = 5;
	public float cdTime = 2f;
	public GameObject[] shapePrefabs;
	public Color[] presetColors;



	public static int totalShapeCounter = 0;
	public static int totalColorCounter = 0;

	// ---------------------------
	// Private variables
	// ---------------------------
	private GameObject shapeInstantiated;
	private GameObject shapeParent;
	private float cdTimer;
	private int shapeAmount;
	private int shapeAmountCounter = 0;

	// Use this for initialization
	void Start ()
	{
		shapeAmount = (int)Random.Range (minNum, maxNum);
		shapeParent = GameObject.Find ("Shapes");
		SetCDTimer ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		cdTimer -= Time.deltaTime;
			
		if (shapeAmountCounter < shapeAmount && cdTimer < 0) {
			int rand = Random.Range (0, shapePrefabs.Length);
			Vector3 pos = new Vector3 (Random.Range (0, 10), Random.Range (0, 10), Random.Range (0, 10));
			InstantiateShape (rand, pos);
			AssignColor ();
			shapeAmountCounter++;
			SetCDTimer ();
		}
	}

	// Instantiate a shape
	void InstantiateShape (int _num, Vector3 _pos)
	{
		shapeInstantiated = Instantiate (shapePrefabs [_num], _pos, Quaternion.identity) as GameObject;
		shapeInstantiated.transform.parent = shapeParent.transform;
	}

	// Assign a color to the instantiated shape
	void AssignColor ()
	{
		int rand = (int)Random.Range (0, presetColors.Length);
		shapeInstantiated.GetComponent<Renderer> ().material.color = presetColors [rand];
	}

	void SetCDTimer ()
	{
		cdTimer = cdTime;
	}
}
