using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableItem : MonoBehaviour {
	[HideInInspector] public Vector3 startPosition;
	private Rigidbody rb;
	private Vector3 offset;
	private float itemScreenZ;

	private void Awake() {
		rb = GetComponent<Rigidbody>();
		startPosition = transform.position;
	}

	void OnMouseDown() {
		if (rb != null) {
			rb.constraints = RigidbodyConstraints.FreezeAll;
		}
		
		itemScreenZ = Camera.main.WorldToScreenPoint(transform.position).z;
		offset = transform.position - GetMouseAsWorldPoint();
	}
	
	private Vector3 GetMouseAsWorldPoint() {
		Vector3 mousePoint = Input.mousePosition;
		mousePoint.z = itemScreenZ;
		
		return Camera.main.ScreenToWorldPoint(mousePoint);
	}
	
	private void OnMouseDrag() {
		Vector3 dragPosition = GetMouseAsWorldPoint() + offset;
		itemScreenZ += Input.mouseScrollDelta.y / 10;
		transform.position = dragPosition;
	}

	private void OnMouseUp() {
		if (rb != null) {
			rb.constraints = RigidbodyConstraints.None;
			rb.velocity = Vector3.zero;
		}
	}
}
