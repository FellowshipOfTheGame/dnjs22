using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour {

	[SerializeField] private float PanSpeed = 20f;

	[SerializeField] private float[] BoundsX = new float[]{-10f,5f};

	private Camera cam;
	private Vector3 lastPanPosition;
	private int panFingerId; // Touch mode only

	private bool wasZoomingLastFrame; // Touch mode only
	private Vector2[] lastZoomPositions; // Touch mode only
	private bool isMenuOpen = false;
	private bool isDragging = false;

	void Awake() {
		cam = Camera.main;
	}

	void Update() {
		if (isMenuOpen || !isDragging) {
			return;
		}
		if (Input.touchSupported && Application.platform != RuntimePlatform.WebGLPlayer) {
			HandleTouch();
		} else {
			HandleMouse();
		}
	}

	public void StartDragging(){
		print("start");
		isDragging = true;
	}

	public void StopDragging(){
		print("stop");
		isDragging = false;
	}

	void HandleTouch() {
		if(Input.touchCount == 1){
			// If the touch began, capture its position and its finger ID.
			// Otherwise, if the finger ID of the touch doesn't match, skip it.
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began) {
				lastPanPosition = touch.position;
				panFingerId = touch.fingerId;
			} else if (touch.fingerId == panFingerId && touch.phase == TouchPhase.Moved) {
				PanCamera(touch.position);
			}
		}
	}

	void HandleMouse() {
		// On mouse down, capture it's position.
		// Otherwise, if the mouse is still down, pan the camera.
		if (Input.GetMouseButtonDown(0)) {
			lastPanPosition = Input.mousePosition;
		} else if (Input.GetMouseButton(0)) {
			PanCamera(Input.mousePosition);
		}
	}

	void PanCamera(Vector3 newPanPosition) {
		// Determine how much to move the camera
		Vector3 offset = cam.ScreenToViewportPoint(lastPanPosition - newPanPosition);
		Vector3 move = new Vector3(-offset.x * PanSpeed, 0, 0);
		
		// Perform the movement
		transform.Translate(move, Space.World);  
		
		// Ensure the camera remains within bounds.
		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp(transform.position.x, BoundsX[0], BoundsX[1]);
		transform.position = pos;

		// Cache the position
		lastPanPosition = newPanPosition;
	}
}
