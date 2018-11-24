using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.Networking.NetworkSystem;
using System;
using Newtonsoft.Json;

public class ArmyBehaviour : MonoBehaviour
{
	NetworkClient myClient;

//	[SerializeField] private UIActions MenuManager;
	[SerializeField] private string UniqueID;
	[SerializeField] private Team MyTeam;

	[SerializeField] private int team;
	[SerializeField] private int money;
	[SerializeField] private DateTime lastLogin;

	void Start()
	{
		SetupClient();
	}

	public void SetupClient()
	{
		myClient = new NetworkClient();
		myClient.RegisterHandler(MsgType.Connect, OnConnected);
		myClient.RegisterHandler (MyMsgType.MessageCommand, OnCommandReturn);
		// myClient.RegisterHandler(MyMsgType.MessageCommand, PrintReturn);
		//myClient.Connect("lessertest.eastus.cloudapp.azure.com", 4444);
		myClient.Connect("127.0.0.1", 4444);
		UniqueID = SystemInfo.deviceUniqueIdentifier;
	}

	public void SetupLocalClient()
	{
		myClient = ClientScene.ConnectLocalServer();
		myClient.RegisterHandler(MsgType.Connect, OnConnected);
	}

	private void OnCommandReturn(NetworkMessage netMsg){
		string beginMessage = netMsg.ReadMessage<StringMessage>().value;

		if(beginMessage != "Error"){
			MessageCommand msg = JsonConvert.DeserializeObject<MessageCommand>(beginMessage);
			if(msg.type == 2){	// Login
				team = msg.team;
				money = msg.money;
				lastLogin = Convert.ToDateTime (msg.lastLogin);
				Debug.Log("Login successfull!");
			}
		}
		else
			Debug.Log("Error found at receiving message");
	}
	// void PrintReturn(NetworkMessage netMsg)
	// {
	//     string beginMessage = netMsg.ReadMessage<StringMessage>().value;
	//     MessageCommand msg = JsonConvert.DeserializeObject<MessageCommand>(beginMessage);
	//     Debug.Log("Client\nIssue: " + msg.issue + "\nPlayer Id: " + msg.player + "\nTeam name: " + msg.troop.team.name);
	// }

	public void OnLoginReturn(NetworkMessage netMsg){
		string beginMessage = netMsg.ReadMessage<StringMessage>().value;
		MessageCommand msg = JsonConvert.DeserializeObject<MessageCommand>(beginMessage);
	}

	private void OnConnected(NetworkMessage netMsg)
	{
		Debug.Log("Connected");
		//MenuManager.ToggleLoadingScreen();
	}

	public void BuyTroop(){
		print("BOUGHT 1 TROOP");
		MessageCommand msg = new MessageCommand();
		msg.issue = DateTime.Now;
		msg.player = UniqueID;
		msg.troop = new Troop(1, MyTeam);
		myClient.Send(MyMsgType.MessageCommand, new StringMessage(JsonConvert.SerializeObject(msg)));
	}

	public void SendTroop(int troopNum){
		print("SENT " + troopNum + " TROOPS");
		MessageCommand msg = new MessageCommand();
		msg.issue = DateTime.Now;
		msg.player = UniqueID;
		msg.troop = new Troop(troopNum, MyTeam);
		myClient.Send(MyMsgType.MessageCommand, new StringMessage(JsonConvert.SerializeObject(msg)));
	}

	private void Login(){
		MessageCommand msg = new MessageCommand();
		msg.player = UniqueID;
		msg.type = 2;
		myClient.Send (MyMsgType.MessageCommand, new StringMessage (JsonConvert.SerializeObject (msg)));
	}
}