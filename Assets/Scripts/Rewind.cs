﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rewind : MonoBehaviour
{
	public InputMaster controls;
	[Range(0, 7)]
	public float maxRecordTime = 5f;
	[Range(0, 2)]
	public float slowdownSpeed = 1.5f;
	[Range(0, 1)]
	public float slowdownDuration = 0.8f;

	
	private List<PointInTime> points;
	private Rigidbody2D rb;
	public bool rewinding { get; private set; }
	private Vector3 mostRecentVelocity;

	void Awake() {
		controls = new InputMaster();
		controls.Player.Rewind.performed += ctx => StartRewind();
		controls.Player.Rewind.canceled += ctx => StopRewind();
	}

	void Start() {
		rewinding = false;
		rb = GetComponent<Rigidbody2D>();
		points = new List<PointInTime>();
		mostRecentVelocity = rb.velocity;
	}

	void FixedUpdate() {
		if (rewinding)
			DoRewind();
		else
			Record();
	}

	void DoRewind() {
		if(points.Count > 0) {
			PointInTime point = points[0];
			transform.position = point.position;
			transform.rotation = point.rotation;
			mostRecentVelocity = point.velocity;
			points.RemoveAt(0);
		}
		else {
			StopRewind();
		}
	}

	void Record() {
		if (rb.velocity.magnitude < 0.2f)
			return;

		// Remove from the end
		if(points.Count > Mathf.Round(maxRecordTime / Time.fixedDeltaTime)) {
			points.RemoveAt(points.Count - 1);
		}
		points.Insert(0, new PointInTime(
			transform.position, transform.rotation, rb.velocity
		));
	}

	void StartRewind() {
		rewinding = true;
		Time.timeScale = slowdownSpeed;
		rb.isKinematic = true;
		GetComponent<Collider2D>().enabled = false;
	}

	void StopRewind() {
		rewinding = false;
		Time.timeScale = 1.0f;
		rb.isKinematic = false;
		GetComponent<Collider2D>().enabled = true;
		rb.velocity = mostRecentVelocity;

	}

	void OnEnable() {
		controls.Enable();
	}

	void OnDisable() {
		controls.Disable();
	}
}
