using System.Collections.Generic;
using UnityEngine;

public class PositionStore : MonoBehaviour
{
	public InputMaster controls;
	[Range(0, 7)]
	public float maxRecordTime = 5f;
	[Range(0, 1)]
	public float slowdownSpeed = 0.5f;
	[Range(0, 1)]
	public float slowdownDuration = 0.8f;


	private List<PointInTime> points;
	private Rigidbody rb;
	private bool rewinding = false;

	void Awake() {
		controls = new InputMaster();
		controls.Player.Rewind.performed += ctx => StartRewind();
		controls.Player.Rewind.canceled += ctx => StopRewind();
	}

	void Start() {
		rb = GetComponent<Rigidbody>();
		points = new List<PointInTime>();
	}

	void FixedUpdate() {
		if (rewinding)
			Rewind();
		else
			Record();
	}

	void Rewind() {
		if(points.Count > 0) {
			PointInTime point = points[0];
			transform.position = point.position;
			transform.rotation = point.rotation;
			rb.velocity = point.velocity;

			points.RemoveAt(0);
		}
		else {
			StopRewind();
		}
	}

	void Record() {
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
	}

	void StopRewind() {
		rewinding = false;
		Time.timeScale = 1.0f;
	}

	void OnEnable() {
		controls.Enable();
	}

	void OnDisable() {
		controls.Disable();
	}

	void OnMouseOver() {
		Debug.Log("Moused over");	
	}
}
