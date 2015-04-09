using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour {

	public GameObject GameHandler;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Text> ().text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		int score = GameHandler.GetComponent<GameHandler>().GetScore();
		gameObject.GetComponent<Text> ().text = score+"";
	}
}
