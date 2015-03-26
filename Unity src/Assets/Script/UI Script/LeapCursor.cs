using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeapCursor : MonoBehaviour {

	// collider and rigidbody for get collision
	private BoxCollider boxCollider;
	private Rigidbody rigidbody;

	// Rect transform for getting the width and height for the image / button
	private RectTransform cursorRect;

	// set it is trigger or not
	public bool isTrigger;

	// Sensitive setting
	public float sensitive;

	// LineRender for showing the feedback for user
	private LineRenderer lineRender;

	// Scrollbar to scale the time line
	public GameObject LoadingBar;
	private Scrollbar timeBar;

	// Doing Trigger
	public bool isTriggering = false;

	void Awake() {
		// trigger event
		this.gameObject.AddComponent<BoxCollider> ();
		// trigger event
		this.gameObject.AddComponent<Rigidbody> ();
		// user feedback
		this.gameObject.AddComponent<LineRenderer> ();

		boxCollider = this.gameObject.GetComponent<BoxCollider> ();
		cursorRect = this.gameObject.GetComponent<RectTransform> ();
		rigidbody = this.gameObject.GetComponent<Rigidbody> ();
		lineRender = this.gameObject.GetComponent<LineRenderer> ();
		timeBar = LoadingBar.GetComponent<Scrollbar> ();
	}

	// Use this for initialization
	void Start () {
		InitCursor ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitCursor() {
		boxCollider.size = new Vector3(cursorRect.rect.width, cursorRect.rect.height, 1);
		boxCollider.isTrigger = isTrigger;
		// freeze the rotation
		rigidbody.freezeRotation = true;
		rigidbody.useGravity = false;
	}

	public void StartLoadingBar(int totalCount, int currentCount) {
		timeBar.size += 0.01f / ( totalCount / 2 );
		Debug.Log ("Total Count: "+totalCount+", Current Count: "+currentCount);
	}

	public void ResetLoadingBar(){
		timeBar.size = 0.0f;
	}
}
