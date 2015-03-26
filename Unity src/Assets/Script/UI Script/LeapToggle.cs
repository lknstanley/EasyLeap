using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeapToggle : MonoBehaviour {

	// Box Collider to handle the cursor interact
	private BoxCollider boxCollider;

	// Rect trans to get information
	private RectTransform toggleRect;

	// for count time
	private int count;
	private bool isCounting;

	// Cursor Tag Name
	public string cursorTag;

	// Is it tigger?
	public bool isTrigger;

	// for user to optimize the count time
	public int countTime;



	void Awake() {
		this.gameObject.AddComponent<BoxCollider> ();
		boxCollider = this.gameObject.GetComponent<BoxCollider> ();
		toggleRect = this.gameObject.GetComponent<RectTransform> ();
	}

	// Use this for initialization
	void Start () {
		InitToogle ();
		InvokeRepeating ("CountDown", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitToogle() {
		boxCollider.size = new Vector3 (toggleRect.rect.width, toggleRect.rect.height, 1);
		boxCollider.isTrigger = isTrigger;
		if(countTime < 0) {
			count = 3;
		} else {
			count = countTime;
		}
	}

	void CountDown() {
		if(count > 0 && isCounting) {
			count--;
			Debug.Log ("Left Time: " + count);
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == cursorTag){
			InitToogle();
		}
	}
	
	void OnTriggerStay(Collider other) {
		if(other.tag == cursorTag) {
			//Debug.Log ("Stay");
			isCounting = true; 
			other.GetComponent<LeapCursor>().StartLoadingBar(countTime, count);
			if(count == 0) {
				if(this.gameObject.GetComponent<Toggle>().isOn) {
					this.gameObject.GetComponent<Toggle>().isOn = false;
				}else{
					this.gameObject.GetComponent<Toggle>().isOn = true;
				}
				InitToogle();
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag == cursorTag) {
			Debug.Log ("Cursor Leave");
			other.GetComponent<LeapCursor>().ResetLoadingBar();
			InitToogle ();
		}
	}

}
