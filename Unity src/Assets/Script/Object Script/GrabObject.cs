using UnityEngine;
using System.Collections;

public class GrabObject : MonoBehaviour {

	public string ControllerTag = "LeapController";
	//private SpringJoint connectPoint;

	private bool isGrabbing = false;

	// Use this for initialization
	void Start () {
		//this.gameObject.AddComponent<SpringJoint> ();
		//connectPoint = this.gameObject.GetComponent<SpringJoint> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DoEvent(Rigidbody target) {
		isGrabbing = true;
		if(this.gameObject.GetComponent<SpringJoint>() == null) {
			this.gameObject.AddComponent<SpringJoint> ();
			this.gameObject.GetComponent<SpringJoint> ().connectedBody = target;
		} else {
			this.gameObject.GetComponent<SpringJoint>().spring = 2.0f;
		}
	}

	public void Release() {
		if(this.gameObject.GetComponent<SpringJoint>() != null) {
			this.gameObject.GetComponent<SpringJoint> ().spring = 0.0f;
		}
	}

	public bool IsGrabbing() {
		return isGrabbing;
	}
}
