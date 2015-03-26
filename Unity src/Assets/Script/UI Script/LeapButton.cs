using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeapButton : MonoBehaviour {

	// create box collider
	private BoxCollider boxCollider;
	// get button script component
	private RectTransform buttonRect;

	// Cursor Tag Name?
	public string cursorTag;

	// Is it tigger?
	public bool isTrigger;

	// for count time
	private int count;
	private bool isCounting;

	// User Setting for Count time the button
	public int countTime;


	void Awake() {
		this.gameObject.AddComponent<BoxCollider> ();
		boxCollider = this.gameObject.GetComponent<BoxCollider> ();
		buttonRect = this.gameObject.GetComponent<RectTransform> ();
	}

	// Use this for initialization
	void Start () {
		InitBtn ();
		InvokeRepeating ("CountDown",1,1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitBtn() {
		boxCollider.size = new Vector3 (buttonRect.rect.width, buttonRect.rect.height, 1);
		boxCollider.isTrigger = isTrigger;
		// init for counter
		if(countTime < 0) {
			count = 2;
		} else { 
			count = countTime;
		}
		isCounting = false;
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Enter");
		if(other.tag == cursorTag){
			InitBtn();
		}
	}

	void OnTriggerStay(Collider other) {
		if(other.tag == cursorTag) {
			isCounting = true; 
			other.GetComponent<LeapCursor>().StartLoadingBar(countTime, count);
			if(count == 0) {
				this.gameObject.GetComponent<Button>().onClick.Invoke();
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.tag == cursorTag) {
			Debug.Log ("Cursor Leave");
			other.GetComponent<LeapCursor>().ResetLoadingBar();
			InitBtn ();
		}
	}

	void CountDown() {
		if(count > 0 && isCounting) {
			count--;
			Debug.Log ("Left Time: " + count);
		}
	}
}
