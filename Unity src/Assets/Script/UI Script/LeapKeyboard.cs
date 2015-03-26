using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeapKeyboard : MonoBehaviour {

	public GameObject key;

	// Use this for initialization
	void Start () {
		InitKeyboard ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void InitKeyboard(){
		for(int i = 1; i < 26 ; i++) {
			GameObject newObj = Instantiate(key) as GameObject;
			newObj.transform.SetParent(this.gameObject.transform, false);
			if( i < 15 ) {
				newObj.transform.position = new Vector3(key.transform.position.x + key.GetComponent<RectTransform>().rect.width * i
				                                        ,key.transform.position.y
				                                        ,key.transform.position.z);
			} else {
				newObj.transform.position = new Vector3(key.transform.position.x + key.GetComponent<RectTransform>().rect.width * (i-15)
				                                        ,key.transform.position.y - key.GetComponent<RectTransform>().rect.height
				                                        ,key.transform.position.z);
			}
			switch(i){
			case 1: newObj.GetComponentInChildren<Text>().text = "B"; newObj.name = "B"; break;
			case 2: newObj.GetComponentInChildren<Text>().text = "C"; newObj.name = "C"; break;
			case 3: newObj.GetComponentInChildren<Text>().text = "D"; newObj.name = "D"; break;
			case 4: newObj.GetComponentInChildren<Text>().text = "E"; newObj.name = "E"; break;
			case 5: newObj.GetComponentInChildren<Text>().text = "F"; newObj.name = "F"; break;
			case 6: newObj.GetComponentInChildren<Text>().text = "G"; newObj.name = "G"; break;
			case 7: newObj.GetComponentInChildren<Text>().text = "H"; newObj.name = "H"; break;
			case 8: newObj.GetComponentInChildren<Text>().text = "I"; newObj.name = "I"; break;
			case 9: newObj.GetComponentInChildren<Text>().text = "J"; newObj.name = "J"; break;
			case 10: newObj.GetComponentInChildren<Text>().text = "K"; newObj.name = "K"; break;
			case 11: newObj.GetComponentInChildren<Text>().text = "L"; newObj.name = "L"; break;
			case 12: newObj.GetComponentInChildren<Text>().text = "M"; newObj.name = "M"; break;
			case 13: newObj.GetComponentInChildren<Text>().text = "N"; newObj.name = "N"; break;
			case 14: newObj.GetComponentInChildren<Text>().text = "O"; newObj.name = "O"; break;
			case 15: newObj.GetComponentInChildren<Text>().text = "P"; newObj.name = "P"; break;
			case 16: newObj.GetComponentInChildren<Text>().text = "Q"; newObj.name = "Q"; break;
			case 17: newObj.GetComponentInChildren<Text>().text = "R"; newObj.name = "R"; break;
			case 18: newObj.GetComponentInChildren<Text>().text = "S"; newObj.name = "S"; break;
			case 19: newObj.GetComponentInChildren<Text>().text = "T"; newObj.name = "T"; break;
			case 20: newObj.GetComponentInChildren<Text>().text = "U"; newObj.name = "U"; break;
			case 21: newObj.GetComponentInChildren<Text>().text = "V"; newObj.name = "V"; break;
			case 22: newObj.GetComponentInChildren<Text>().text = "W"; newObj.name = "W"; break;
			case 23: newObj.GetComponentInChildren<Text>().text = "X"; newObj.name = "X"; break;
			case 24: newObj.GetComponentInChildren<Text>().text = "Y"; newObj.name = "Y"; break;
			case 25: newObj.GetComponentInChildren<Text>().text = "Z"; newObj.name = "Z"; break;
			}
		}
	}
}
