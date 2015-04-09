using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Hand_Controller))]
public class HandControllerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		Hand_Controller myScript = (Hand_Controller)target;

		EditorGUILayout.HelpBox ("Basic GameObject Seup", MessageType.Info);

		myScript.camObj = (GameObject) EditorGUILayout.ObjectField ("Camera Object", myScript.camObj, typeof(GameObject), true);
		myScript.PlayerObject = (GameObject) EditorGUILayout.ObjectField ("Player Object", myScript.PlayerObject, typeof(GameObject), true);

		EditorGUILayout.HelpBox ("Hands Controller Setting", MessageType.Info);

		myScript.isPlayerController = EditorGUILayout.Toggle ("Is Player Controller", myScript.isPlayerController);
		if(myScript.isPlayerController) {
			EditorGUILayout.HelpBox("Rotate & Forward Speed Setting", MessageType.Info);
			myScript.RotateOffset = EditorGUILayout.FloatField("Rotate Offset", myScript.RotateOffset);
			myScript.ForwardSpeed = EditorGUILayout.FloatField("Forward Speed", myScript.ForwardSpeed);
		}
		EditorGUILayout.HelpBox ("One Hand or Two Hands Setting", MessageType.Info);
		myScript.IsTwoHandsController = EditorGUILayout.Toggle ("Is Two Hands Controller", myScript.IsTwoHandsController);

		EditorGUILayout.HelpBox ("Activate the interaction with Leap Object / Leap GUI", MessageType.Info);
		myScript.isInteractWithObjects = EditorGUILayout.Toggle ("Interact With Object", myScript.isInteractWithObjects);
	}
}
