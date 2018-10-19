using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapActions : MonoBehaviour {

	[SerializeField] private GameObject MovableArea;
	private Transform MovableTransform;
	private Vector3 StartDragPosition;
	private Vector3 CurrentDragPosition;
	private bool isDragging;

	void Start(){
		MovableTransform = MovableArea.transform;
	}

	
	public void TouchMap(){
		print("TOUCH!");
		StartDragPosition = Input.mousePosition;
		isDragging = true;
	}

	public void DragMap(){

#if UNITY_ANDROID
		//usando controle de toque no celular
		if(isDragging && Input.touchCount == 0){
			isDragging = false;
		}
		else if(isDragging && Input.touchCount == 1){
			CurrentDragPosition = Input.GetTouch(0).position;
			var DragOffset = Camera.main.ScreenToWorldPoint(CurrentDragPosition.x) - Camera.main.ScreenToWorldPoint(StartDragPosition.x); 
			MovableTransform.position = new Vector3(MovableTransform.position.x + DragOffset, MovableTransform.position.y, MovableTransform.position.z);
		}
#endif

#if UNITY_EDITOR
		//usando o mouse
		if(isDragging){
			CurrentDragPosition = Input.mousePosition;
			var DragOffset = CurrentDragPosition.x - StartDragPosition.x;
			MovableTransform.position = new Vector3(MovableTransform.position.x + DragOffset, MovableTransform.position.y, MovableTransform.position.z);
	
		}
#endif
	}

	public void BeginDragMap(){
		print("entrou");
		if(Input.touchCount == 1){
			StartDragPosition = Input.GetTouch(0).position;
			isDragging = true;
		}

#if UNITY_EDITOR
		StartDragPosition = Input.mousePosition;
		isDragging = true;
#endif

	}
}
