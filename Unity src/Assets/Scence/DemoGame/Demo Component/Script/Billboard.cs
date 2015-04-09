using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

	public GameObject GameHandler;

	public string[] CountObjectTag;

	public string ControllerRelease;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (Camera.main.transform.position, Vector3.up);
	}

	void OnTriggerEnter(Collider other) {
		for(int i = 0; i < CountObjectTag.Length; i++) {
			if(other.tag == CountObjectTag[i]) {
				int tempScore = GameHandler.GetComponent<GameHandler> ().GetScore () + 1;
				if(other.tag == "LeapGrabObject") {
					GameObject.Find (ControllerRelease).GetComponent<Hand_Controller>().ReleaseObject();
				}
				GameHandler.GetComponent<GameHandler>().SetScore(tempScore);
				GameHandler.GetComponent<GameHandler> ().NewTarget ();
				//DestroyObject (other.gameObject);
			}
		}
	}
}
