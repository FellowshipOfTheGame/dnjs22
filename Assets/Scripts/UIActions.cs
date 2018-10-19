using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActions : MonoBehaviour {

	[SerializeField] private GameObject CurrentScreen;
	[SerializeField] private GameObject CurrentWindow;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeScreen(GameObject screen){
		CurrentScreen?.SetActive(false);
		screen.SetActive(true);
		CurrentScreen = screen;
	}

	public void ToggleWindow(GameObject window){
		window.SetActive(!window.activeSelf);
	}

	public void MuteSound(){

	}
}
