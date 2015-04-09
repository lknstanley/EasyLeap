using UnityEngine;
using System.Collections;

public class CamLootAt : MonoBehaviour {

	public GameObject targetObj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.LookAt (targetObj.transform.position);
	}
}
