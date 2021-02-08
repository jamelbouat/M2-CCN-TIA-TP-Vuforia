using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MyVirtualButtonEventHandler : MonoBehaviour{
	protected static int count;
	protected Renderer[] rendererComponents;
    protected TrackableBehaviour mTrackableBehaviour;
	public DefaultTrackableEventHandler defaultTrackableEventHandler;

	void Start(){
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		// Register with the virtual buttons TrackableBehaviour
		var virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();
		for (int i = 0; i < virtualButtonBehaviours.Length; ++i){
			virtualButtonBehaviours[i].RegisterOnButtonPressed(OnButtonPressed);
			virtualButtonBehaviours[i].RegisterOnButtonReleased(OnButtonReleased);
		}
	}
	
	void OnButtonPressed(VirtualButtonBehaviour button) {
		defaultTrackableEventHandler.OnTrackingLost();
		defaultTrackableEventHandler.OnTrackingFound();
		Debug.LogFormat("Button Pressed");
	}
	
	void OnButtonReleased(VirtualButtonBehaviour button) {	}
	
	void Destroy(){
		// Register with the virtual buttons TrackableBehaviour
		var virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();
		for (int i = 0; i < virtualButtonBehaviours.Length; ++i){
			virtualButtonBehaviours[i].UnregisterOnButtonPressed(OnButtonPressed);
			virtualButtonBehaviours[i].UnregisterOnButtonReleased(OnButtonReleased);
		}
	}
}
