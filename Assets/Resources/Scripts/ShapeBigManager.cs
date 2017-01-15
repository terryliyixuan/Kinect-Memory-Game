using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShapeBigManager : MonoBehaviour
{

	// ---------------------------
	// Public variables
	// ---------------------------
	public int minNum = 1;
	public int maxNum = 5;
	public float cdTime = 2f;
	// Declare an array that stores all the shape prefabs
	public GameObject[] shapePrefabs;
	public Color[] presetColors;
	// Declare a string that determines the name of the next scene
	public string nextSceneName;


	// All the counters
	public int totalShapeCounter = 0;
	public int totalColorCounter = 0;
	public int totalBlackCounter = 0;
	public int totalRedCounter = 0;
	public int totalBlueCounter = 0;
	public int totalGreenCounter = 0;
	public int totalYellowCounter = 0;

	// ---------------------------
	// Private variables
	// ---------------------------
	private GameObject shapeInstantiated;
	private GameObject shapeParent;
	private float cdTimer;
	private int shapeAmount;
	private int shapeAmountCounter = 0;
	private int assignedColorNum;
	private int assignedShapeNum;

	// The Awake function that saves all the data in this class
	void Awake ()
	{
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start ()
	{
		shapeAmount = (int)Random.Range (minNum, maxNum);
		shapeParent = GameObject.Find ("Shapes");
		SetCDTimer ();
		SetColorCounters ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		cdTimer -= Time.deltaTime;

		// Keep instantiating shapes until it reaches the preset "shapeAmount"
		if (shapeAmountCounter < shapeAmount && cdTimer < 0) {
			InstantiateShape ();
			AssignColor ();
			CalculateColorCounter ();
			shapeAmountCounter++;
			SetCDTimer ();
		}

		// If it reaches the preset "shapeAmount", jumps to the next scene
		if (shapeAmountCounter >= shapeAmount && SceneManager.GetActiveScene ().name != nextSceneName) {
			SceneManager.LoadScene (nextSceneName);
		}
	}

	// Instantiate a shape
	void InstantiateShape ()
	{
		Vector3 pos = new Vector3 (Random.Range (0, 10), Random.Range (0, 10), Random.Range (0, 10));
		int rand = Random.Range (0, shapePrefabs.Length);
		assignedShapeNum = rand;
		shapeInstantiated = Instantiate (shapePrefabs [rand], pos, Quaternion.identity) as GameObject;
		shapeInstantiated.transform.parent = shapeParent.transform;
	}

	// Assign a color to the instantiated shape
	void AssignColor ()
	{
		int rand = (int)Random.Range (0, presetColors.Length);
		assignedColorNum = rand;
		SpriteRenderer shapeRenderer = shapeInstantiated.GetComponent<SpriteRenderer> ();
		shapeRenderer.color = presetColors [assignedColorNum];
	}

	// Set/Reset timer
	void SetCDTimer ()
	{
		cdTimer = cdTime;
	}

	// Set/Reset all the color counters
	void SetColorCounters ()
	{
		totalBlackCounter = 0;
		totalRedCounter = 0;
		totalBlueCounter = 0;
		totalGreenCounter = 0;
		totalYellowCounter = 0;
	}

	// Calculate all the color counters
	void CalculateColorCounter ()
	{
		switch (assignedColorNum) {
		case 0:
			totalBlackCounter++;
			break;
		case 1:
			totalRedCounter++;
			break;
		case 2:
			totalBlueCounter++;
			break;
		case 3:
			totalGreenCounter++;
			break;
		case 4:
			totalYellowCounter++;
			break;
		}
	}
}
