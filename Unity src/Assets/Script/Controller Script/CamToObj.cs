using UnityEngine;
using System.Collections;

public class CamToObj : MonoBehaviour {

	public GameObject playerObj;
	public float RotateOffset = 3;
	public float FowardSpeed = 1;

	private Vector3 selfForward;

	// Use this for initialization
	void Start () {
		//selfForward = transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
		selfForward = transform.forward;
	}

	public void turnCam(Leap.Vector palmNormal) {
		playerObj.transform.Rotate (0, -palmNormal.x * RotateOffset, 0);
	}

	public void forwardPlayer(Leap.Vector palmNormal) {
		playerObj.transform.Translate (palmNormal.x * FowardSpeed, 0, palmNormal.z * FowardSpeed);
	}

	public void SetRotateOffset(float target){
		this.RotateOffset = target;
	}

	public void SetForwardSpeed(float target){
		this.FowardSpeed = target;
	}
}
