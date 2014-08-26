using UnityEngine;
using System.Collections;

public class autostartrecording : MonoBehaviour {
	
	private bool donerecording = true;
	
	// Use this for initialization
	void Start () {
		Everyplay.StartRecording();
		//#if UNITY_EDITOR
		//Debug.Log("The video recording is not available in the Unity editor. Please compile and run on a device.");
		//#endif
	}

	
}