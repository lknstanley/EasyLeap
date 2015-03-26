using UnityEngine;
using System.Collections;
using Leap;
using System;
using System.IO;

public class Hand_Controller : MonoBehaviour {

	public GameObject camObj;
	private CamToObj camScript;

	// seperate the function for this script
	public bool isPlayerController;

	// Setting up the Leap Motion SDK
	private Leap.Controller leapController = null;
	private bool leapInit = false;

	//variables for the leap frame
	private Leap.Frame leapFrame = null;
	private Leap.Frame frame;

	//what is going on ???
	private Int64 lastFrameID = 0;
	private Int64 leapFrameCounter = 0;

	// Use this for initialization
	void Start () {
		// init the leap motion values
		leapController = new Leap.Controller ();
		leapController.Config.Save ();
		leapInit = true;

		// get script from cam obj
		camScript = camObj.GetComponent<CamToObj> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(leapInit) {
			frame = leapController.Frame ();
			if(frame.IsValid && (frame.Id != lastFrameID)) {
				leapFrame = frame;
				lastFrameID = frame.Id;
				leapFrameCounter++;
				if(isPlayerController) {
					PlayerController();
				}
			}
		}
	}

	void PlayerController() {
		HandList handList = frame.Hands;
		Hand right = handList.Rightmost;
		Hand left = handList.Leftmost;

		FingerList fingerList = frame.Fingers;
		

		Leap.Vector palmNormal;
		if(right != null && fingerList.Count != 0) {
			palmNormal = right.PalmNormal;
			Debug.Log ("Palm Normal: "+palmNormal);
			if(camObj != null) {
				//targetObj.rigidbody.AddForce(new Vector3(-palmNormal.x , 0, palmNormal.z ), ForceMode.VelocityChange);
				camScript.turnCam(palmNormal);
				camScript.forwardPlayer(palmNormal);
			}
		}
	}
}
