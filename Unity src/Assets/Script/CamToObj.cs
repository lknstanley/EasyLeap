using UnityEngine;
using System.Collections;

public class CamToObj : MonoBehaviour {

	public GameObject playerObj;

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
		playerObj.transform.Rotate (0, -palmNormal.x * 2, 0);
	}

	public void forwardPlayer(Leap.Vector palmNormal) {
		playerObj.transform.Translate (palmNormal.x, 0, palmNormal.z);
	}
}
