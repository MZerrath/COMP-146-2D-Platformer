using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {
	public Transform target;
	public float smoothTime = 0.2f;

	private Vector3 _velocity = Vector3.zero;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void LateUpdate() {
		// It seems setting the Y axis to "0" is enough to lock the camera on the Y axis.
		Vector3 targetPosition = new Vector3(target.position.x, 0, transform.position.z);
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
	}
}
