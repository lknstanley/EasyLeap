using UnityEngine;
using System.Collections;
using Leap;
using System;
using System.IO;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	
	public GameObject camObj;
	private CamToObj camScript;

	// UI Component
	public GameObject panelOn;
	private Button panelBtnOn;

	public GameObject panelOff;
	private Button panelBtnOff;
	
	// seperate the function for this script
	public bool isUIController;
	
	// Setting up the Leap Motion SDK
	private Leap.Controller leapController = null;
	private Leap.Hand leapHand = null;
	private bool leapInit = false;
	
	//variables for the leap frame
	private Leap.Frame leapFrame = null;
	private Leap.Frame frame;
	
	//what is going on ???
	private Int64 lastFrameID = 0;
	private Int64 leapFrameCounter = 0;
	
	//UI Cursor Control
	public GameObject cursorObj;
	
	// Use this for initialization
	void Start () {
		// init the leap motion values
		leapController = new Leap.Controller ();
		leapController.Config.Save ();
		leapInit = true;
		
		// get script from cam obj
		camScript = camObj.GetComponent<CamToObj> ();

		// get button script from btn game object
		panelBtnOn = panelOn.GetComponent<Button> ();
		panelBtnOff = panelOff.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(leapInit) {
			frame = leapController.Frame ();
			if(frame.IsValid && (frame.Id != lastFrameID)) {
				leapFrame = frame;
				lastFrameID = frame.Id;
				leapFrameCounter++;

				if(isUIController) {
					UIControl();
					
				}
			}
		}
	}

	void UIControl() {
		HandList handList = frame.Hands;
		Hand right = handList.Rightmost;
		Hand left = handList.Leftmost;

		// make a virual interaction box / click / cursor
		InteractionBox iBox = frame.InteractionBox;
		FingerList r_fingerList = right.Fingers;
		Finger frontMost = r_fingerList.Frontmost;
		if(right != null || left != null) {
			if(right != null && frontMost != null) {
				Vector norPos = iBox.NormalizePoint(r_fingerList.Frontmost.StabilizedTipPosition);
				float pX = norPos.x * UnityEngine.Screen.width;
				float pY= norPos.y * UnityEngine.Screen.height;

				float r_x = r_fingerList.Frontmost.StabilizedTipPosition.x;
				float r_y = r_fingerList.Frontmost.StabilizedTipPosition.y;

				cursorObj.transform.position = new Vector3(pX, pY, cursorObj.transform.position.z);

				// used to check the cursor position
				//Debug.Log ("R_X: " + r_x + ", R_Y: " + r_y );

			} 
		}
	}
}
