using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class DetectJoints : MonoBehaviour
{

	private BodySourceManager bodySrcManager;
	public JointType myJointType;
	private Body[] bodies;
	public float multiplier = 10f;

	// Use this for initialization
	void Start ()
	{
		bodySrcManager = GameObject.FindObjectOfType<BodySourceManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		bodies = bodySrcManager.GetData ();
		if (bodies == null) {
			return;
		} else {
			foreach (var body in bodies) {
				if (body == null) {
					continue;
				}
				if (body.IsTracked == true) {
					var pos = body.Joints [myJointType].Position;
					gameObject.transform.position = new Vector3 (pos.X * multiplier, pos.Y * multiplier, transform.position.z);
				}
			}
		}
	}
}
