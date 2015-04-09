using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour {

	public GameObject CorrectPoint;
	public GameObject GrabbableObject;

	private bool isCorrectState;

	public int score = 0;

	// Use this for initialization
	void Start () {
		GrabbableObject.transform.position = new Vector3 (Random.Range(CorrectPoint.transform.position.x - 20.0f, CorrectPoint.transform.position.x + 20.0f),
		                                CorrectPoint.transform.position.y,
		                                Random.Range(CorrectPoint.transform.position.z - 20.0f, CorrectPoint.transform.position.z + 20.0f));
		//Instantiate (GrabbableObject, position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int GetScore() {
		return score;
	}

	public void SetScore(int target){
		score = target;
	}

	public void NewTarget(){
		GrabbableObject.transform.position = new Vector3 (Random.Range(CorrectPoint.transform.position.x - 20.0f, CorrectPoint.transform.position.x + 20.0f),
		                                CorrectPoint.transform.position.y,
		                                Random.Range(CorrectPoint.transform.position.z - 20.0f, CorrectPoint.transform.position.z + 20.0f));
		//Instantiate (GrabbableObject, position, Quaternion.identity);
	}

}
