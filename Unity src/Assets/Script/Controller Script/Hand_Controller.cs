using UnityEngine;
using System.Collections;
using Leap;
using System;
using System.IO;

public class Hand_Controller : MonoBehaviour {

	public GameObject camObj;
	private CamToObj camScript;

	public GameObject PlayerObject;

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

	//Raycast hit object
	private RaycastHit hitObj;

	// One Hands or Two Hands?
	public bool IsTwoHandsController = false;

	// Value For User to modify
	public float RotateOffset = 3;
	public float ForwardSpeed = 1;

	// Tempory for Hit
	private GameObject tempHit;

	// Count Grab objects
	int countGrab = 0;

	// Bool interact with object?
	public bool isInteractWithObjects = false;

	// Use this for initialization
	void Start () {
		// init the leap motion values
		leapController = new Leap.Controller ();
		leapController.Config.Save ();
		leapInit = true;

		// get script from cam obj
		camScript = camObj.GetComponent<CamToObj> ();
		camScript.SetRotateOffset (RotateOffset);
		camScript.SetForwardSpeed (ForwardSpeed);

	}
	
	// Update is called once per frame
	void Update () {
		if(leapInit) {
			frame = leapController.Frame ();
			// Debug.Log (frame.Fingers.Extended().Count); ------ Fingers extended (need to extend to get the fingers count)
			if(frame.IsValid && (frame.Id != lastFrameID)) {
				leapFrame = frame;
				lastFrameID = frame.Id;
				leapFrameCounter++;
				if(isPlayerController) {
					if(!IsTwoHandsController) {
						PlayerThirdPersonController();
					} else {
						PlayerFirstPersonController();
					}
				}
			}
		}
	}

	void PlayerThirdPersonController() {
		HandList handList = frame.Hands;
		Hand right = handList.Rightmost;
		Hand left = handList.Leftmost;

		FingerList fingerList = frame.Fingers.Extended();
		

		Leap.Vector palmNormal;
		if(right != null && frame.Hands.Count != 0) {
			palmNormal = right.PalmNormal;
			if(camObj != null) {
				//targetObj.rigidbody.AddForce(new Vector3(-palmNormal.x , 0, palmNormal.z ), ForceMode.VelocityChange);
				camScript.turnCam(palmNormal);
				camScript.forwardPlayer(palmNormal);
			}
			if(isInteractWithObjects) {
				if(fingerList.Count == 0) {
					// Do Event here
					Debug.Log("Grabbing");
					CheckObjAndUI();
				} else {
					Debug.Log ("Releasing");
					ReleaseObject();
				}
			}
		}
	}

	void PlayerFirstPersonController() {
		HandList handList = frame.Hands;
		Hand right = handList.Rightmost;
		Hand left = handList.Leftmost;
		
		FingerList fingerList = frame.Fingers.Extended();
		
		
		Leap.Vector palmNormal;
		if(right != null) {
			palmNormal = right.PalmNormal;
			Debug.Log ("Palm Normal: "+palmNormal);
			if(camObj != null) {
				//targetObj.rigidbody.AddForce(new Vector3(-palmNormal.x , 0, palmNormal.z ), ForceMode.VelocityChange);
				camScript.turnCam(palmNormal);
				camScript.forwardPlayer(palmNormal);
			}

			if(isInteractWithObjects) {
				if(fingerList.Count == 0) {
					// Do Event here
					Debug.Log("Grabbing");
					CheckObjAndUI();
				} else {
					Debug.Log ("Releasing");
					ReleaseObject();
				}
			}
		}
	}

	void CheckObjAndUI() {
		Vector3 direction = PlayerObject.transform.TransformDirection (Vector3.forward);
		if(Physics.Raycast(PlayerObject.transform.position, direction, out hitObj, 100.0f)) {
			GameObject hit = hitObj.transform.gameObject;
			if(hit.transform.gameObject.tag == "LeapGrabObject" && countGrab == 0) {
				tempHit = hit;
				tempHit.GetComponent<GrabObject>().DoEvent(PlayerObject.transform.rigidbody);
				countGrab++;
			}
		}
	}

	void ReleaseObject() {
		if(tempHit != null && countGrab == 1) {
			tempHit.GetComponent<GrabObject> ().Release ();
			countGrab --;
		}
	}
}
