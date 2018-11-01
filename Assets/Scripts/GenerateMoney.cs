using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMoney : MonoBehaviour {

	public int CurrentMoney;
	public int MoneyPerSecond;

	public UIActions MenuManager;

	// Use this for initialization
	void Start () {
		//pega dinheiro atual
		CurrentMoney = 0;
		InvokeRepeating("GainMoney", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GainMoney(){
		CurrentMoney += MoneyPerSecond;
		MenuManager.UpdateMoneyText(MoneyPerSecond);
	}

	void BuyTroop(int cost){
		CurrentMoney -= cost;
		MenuManager.UpdateMoneyText(-cost);
	}
}
