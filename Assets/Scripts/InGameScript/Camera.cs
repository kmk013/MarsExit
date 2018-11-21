using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
	[HideInInspector]
	public Transform target;

	public float dist = 10.0f;
	public float height = 5.0f;
	public float smoothRotate = 5.0f;

	private Transform tr;

	void Start() {
		tr = GetComponent<Transform>();
		target = GameManager.gm.mainPlayer.GetComponent<Transform>();
	}

	void LateUpdate() {
		tr.position = target.position
			- (Quaternion.Euler(0, 45, 0) * Vector3.forward * dist) 
			+ (Vector3.up * height);
		tr.LookAt(target);
	}
}
