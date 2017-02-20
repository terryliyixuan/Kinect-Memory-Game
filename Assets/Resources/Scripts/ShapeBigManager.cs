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
	// Declare a float the sets the transition waiting time
	public float transistionWaitTime = 3f;
	// Declare an array that stores all the shape prefabs
	public GameObject[] shapePrefabs;
	// Declare an array that stores all the preset colors
	public Color[] presetColors;
	// Declare a string that determines the name of the next scene
	public string nextSceneName;

	// All the color counters
	[HideInInspector]
	public int totalShapeCounter = 0;
	[HideInInspector]
	public int totalColorCounter = 0;
	[HideInInspector]
	public int totalBlackCounter = 0;
	[HideInInspector]
	public int totalRedCounter = 0;
	[HideInInspector]
	public int totalBlueCounter = 0;
	[HideInInspector]
	public int totalGreenCounter = 0;
	[HideInInspector]
	public int totalYellowCounter = 0;

	// All the shape counters
	[HideInInspector]
	public int totalCircleCounter = 0;
	[HideInInspector]
	public int totalRectCounter = 0;
	[HideInInspector]
	public int totalTriangleCounter = 0;
	[HideInInspector]
	public int totalPenagonCounter = 0;


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
	// Declare a float that counts down the transition waiting time
	private float transitionWaitTimer;
	// Declare a bool that tells if it is good to start counting down waiting time
	private bool isGoodToWaitForSwitch = false;
	// Declare bools that tells if a certain color has appeared
	private bool hasBlackAppeared = false;
	private bool hasRedAppeared = false;
	private bool hasBlueAppeared = false;
	private bool hasGreenAppeared = false;
	private bool hasYellowAppeared = false;


	// The Awake function that saves all the data in this class
	void Awake ()
	{
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start ()
	{
		shapeAmount = (int)Random.Range (minNum, maxNum);
		totalShapeCounter = shapeAmount;
		shapeParent = GameObject.Find ("Shapes");
		SetCDTimer ();
		SetColorCounters ();
		SetShapeCounters ();
		// Set the transition waiting time
		transitionWaitTimer = transistionWaitTime;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (CountDownToStart.isCountDownOver == true) {
			cdTimer -= Time.deltaTime;

			// Keep instantiating shapes until it reaches the preset "shapeAmount"
			if (shapeAmountCounter < shapeAmount && cdTimer < 0) {
				InstantiateShape ();
				AssignColor ();
				CalculateColorCounter ();
				CalculateShapeCounter ();
				shapeAmountCounter++;
				SetCDTimer ();
			}

			// If it reaches the preset "shapeAmount"...
			// ... We tell the game it is good to count down waiting time
			if (shapeAmountCounter >= shapeAmount && isGoodToWaitForSwitch == false) {
				isGoodToWaitForSwitch = true;
			}

			// If "isGoodToWaitForSwitch" is true...
			// ... We count down the wait timer
			if (isGoodToWaitForSwitch == true) {
				transitionWaitTimer -= Time.deltaTime;
			}

			// If "transitionWaitTimer" is less than 0...
			// ... We switch the scene
			if (transitionWaitTimer <= 0 && SceneManager.GetActiveScene ().name != nextSceneName) {
				SceneManager.LoadScene (nextSceneName);
			}
		}
	}

	// Instantiate a shape
	void InstantiateShape ()
	{
		Vector3 pos = new Vector3 (Random.Range (-Screen.width / 2, Screen.width / 2), Random.Range (-Screen.height / 2, Screen.height / 2), 0);
		pos = Camera.main.WorldToViewportPoint (pos);
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
			if (hasBlackAppeared == false) {
				totalColorCounter++;
				hasBlackAppeared = true;
			}
			break;
		case 1:
			totalRedCounter++;
			if (hasRedAppeared == false) {
				totalColorCounter++;
				hasRedAppeared = true;
			}
			break;
		case 2:
			totalBlueCounter++;
			if (hasBlueAppeared == false) {
				totalColorCounter++;
				hasBlueAppeared = true;
			}
			break;
		case 3:
			totalGreenCounter++;
			if (hasGreenAppeared == false) {
				totalColorCounter++;
				hasGreenAppeared = true;
			}
			break;
		case 4:
			totalYellowCounter++;
			if (hasYellowAppeared == false) {
				totalColorCounter++;
				hasYellowAppeared = true;
			}
			break;
		}
	}

	// Set/Reset all the shape counters
	void SetShapeCounters ()
	{
		totalCircleCounter = 0;
		totalRectCounter = 0;
		totalPenagonCounter = 0;
		totalTriangleCounter = 0;
	}

	// Calculate all the color counters
	void CalculateShapeCounter ()
	{
		switch (assignedShapeNum) {
		case 0:
			totalCircleCounter++;
			break;
		case 1:
			totalPenagonCounter++;
			break;
		case 2:
			totalRectCounter++;
			break;
		case 3:
			totalTriangleCounter++;
			break;
		}
	}
}
