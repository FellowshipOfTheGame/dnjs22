using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIActions : MonoBehaviour {

	[SerializeField] private GameObject CurrentScreen;
	[SerializeField] private GameObject CurrentWindow;
	[SerializeField] private GameObject LoadingScreen;
	[SerializeField] private Text MoneyText;
	[SerializeField] private Text TroopsText;

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

	public void ToggleLoadingScreen(){
		LoadingScreen.SetActive(!LoadingScreen.activeSelf);
	}

	public void UpdateMoneyText(int change){
		MoneyText.text = (Int32.Parse(MoneyText.text) + change).ToString();
	}

	public void UpdateTroopsText(int change){
		TroopsText.text = (Int32.Parse(TroopsText.text) + change).ToString();
	}
}
