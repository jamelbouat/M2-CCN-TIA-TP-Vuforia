 using UnityEngine;
 
 public class SphereAnimationScript : MonoBehaviour{
	public GameObject astronaut;
	public GameObject drone;
	private bool isAstronautFound = false;
	private bool isDroneFound = false;

	public void OnAstronautFound() {
		Debug.LogFormat("Found Astronaut");
		this.isAstronautFound = true;
	}
	public void OnAstronautLost() {
		Debug.LogFormat("Lost Astronaut");
		this.isAstronautFound = false;
	}
	public void OnDroneFound() {
		Debug.LogFormat("Found Drone");
		this.isDroneFound = true;
	}
	public void OnDroneLost() {
		Debug.LogFormat("Lost Drone");
		this.isDroneFound = false;
	}
	
	public void Update() {		
		Vector3 spherePosition = this.transform.position;
		Vector3 astronautPosition = astronaut.transform.position;
		Vector3 dronePosition = drone.transform.position;
		
		if (isAstronautFound && isDroneFound){
			Debug.LogFormat("Targets are found");		
			this.transform.position = Vector3.MoveTowards(spherePosition, dronePosition, 1f * Time.deltaTime);
		} else {
			this.transform.position = Vector3.MoveTowards(spherePosition, astronautPosition, 5f * Time.deltaTime);
		}
	}
 }