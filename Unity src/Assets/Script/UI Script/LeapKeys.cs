using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeapKeys : MonoBehaviour {

	// Set the box collider for trigger to the cursor
	private BoxCollider boxCollider;

	// Cursor Tag Name?
	public string cursorTag;
	
	// Is it tigger?
	public bool isTrigger;
	
	// for count time
	private int count;
	private bool isCounting;
	
	// User Setting for Count time the button
	public int countTime;

	// Key Rect trans
	private RectTransform keyRect;

	// Input field object
	public GameObject LeapInputField;

	void Awake() {
		this.gameObject.AddComponent<BoxCollider> ();

		boxCollider = this.gameObject.GetComponent<BoxCollider> ();
		keyRect = this.gameObject.GetComponent<RectTransform> ();
	}

	// Use this for initialization
	void Start () {
		InitKey ();
		InvokeRepeating ("CountDown", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitKey() {
		boxCollider.size = new Vector3 (keyRect.rect.width, keyRect.rect.height, 1);
		boxCollider.isTrigger = isTrigger;
		if(countTime < 0){
			count = 3;
		}else{
			count = countTime;
		}
		isCounting = false;
	}

	void CountDown() {
		if(count > 0 && isCounting) {
			count--;
			Debug.Log ("Left Time: " + count);
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == cursorTag){
			InitKey();
		}
	}
	
	void OnTriggerStay(Collider other) {
		if(other.tag == cursorTag) {
			isCounting = true; 
			other.GetComponent<LeapCursor>().StartLoadingBar(countTime, count);
			if(count == 0) {
				LeapInputField.GetComponent<InputField>().text += this.gameObject.name;
				count = countTime;
				isCounting = false;
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag == cursorTag) {
			Debug.Log ("Cursor Leave");
			other.GetComponent<LeapCursor>().ResetLoadingBar();
			InitKey ();
		}
	}
}
