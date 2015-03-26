using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeapInputField : MonoBehaviour {

	// box collider to interact with leap cursor
	private BoxCollider boxCollider;

	// rect trans for getting the width and height
	private RectTransform fieldRect;

	// Cursor Tag Name
	public string cursorTag;

	// Is it trigger?
	public bool isTrigger;

	// Input field is activated?
	private bool isActivated;

	// for counting the time
	public int countTime;
	private int count;
	private bool isCounting;

	// Input Field Elements for this GameObject
	private InputField inputField;

	// Virtual Keyboard!
	public GameObject virtualKeyboard;

	void Awake() {
		this.gameObject.AddComponent<BoxCollider> ();
		boxCollider = this.gameObject.GetComponent<BoxCollider> ();
		fieldRect = this.gameObject.GetComponent<RectTransform> ();
		inputField = this.gameObject.GetComponent<InputField> ();
	}

	// Use this for initialization
	void Start () {
		InitInputField ();
		InvokeRepeating ("CountDown",1,1);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void InitInputField() {
		boxCollider.size = new Vector3 (fieldRect.rect.width, fieldRect.rect.height, 1);
		boxCollider.isTrigger = isTrigger;
		isActivated = false;
		isCounting = false;
		if(countTime < 0) {
			count = 3;
		} else {
			count = countTime;
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == cursorTag){
			InitInputField();
		}
	}
	
	void OnTriggerStay(Collider other) {
		if(other.tag == cursorTag) {
			isCounting = true; 
			other.GetComponent<LeapCursor>().StartLoadingBar(countTime, count);
			if(count == 0) {
				if(!inputField.isFocused) {
					inputField.enabled = true;
					inputField.Select();
					inputField.ActivateInputField();
					isActivated = true;
				}else{
					inputField.enabled = false;
					isActivated = false;
				}
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag == cursorTag) {
			Debug.Log ("Cursor Leave");
			other.GetComponent<LeapCursor>().ResetLoadingBar();
			InitInputField ();
		}
	}

	void CountDown() {
		if(count > 0 && isCounting) {
			count--;
			Debug.Log ("Left Time: " + count);
		}
	}

	public void InputFromVirtualKeyBoard(GameObject word) {
		inputField.text += word.name;
	}
}
