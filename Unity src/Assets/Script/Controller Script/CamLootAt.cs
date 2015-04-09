using UnityEngine;
using System.Collections;

public class CamLootAt : MonoBehaviour {

	public GameObject targetObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.transform.position = new Vector3 (targetObj.transform.position.x, targetObj.transform.position.y, targetObj.transform.position.z - 5);
		gameObject.transform.LookAt (targetObj.transform);
	}
}
