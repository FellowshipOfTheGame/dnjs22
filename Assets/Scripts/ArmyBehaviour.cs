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

    [SerializeField] private UIActions MenuManager;
    [SerializeField] private string UniqueID;
    [SerializeField] private Team MyTeam;

    void Start()
    {
        SetupClient();
    }

    public void SetupClient()
    {
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        // myClient.RegisterHandler(MyMsgType.MessageCommand, PrintReturn);
        myClient.Connect("127.0.0.1", 4444);
        UniqueID = SystemInfo.deviceUniqueIdentifier;
    }

    public void SetupLocalClient()
    {
        myClient = ClientScene.ConnectLocalServer();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
    }

    // void PrintReturn(NetworkMessage netMsg)
    // {
    //     string beginMessage = netMsg.ReadMessage<StringMessage>().value;
    //     MessageCommand msg = JsonConvert.DeserializeObject<MessageCommand>(beginMessage);
    //     Debug.Log("Client\nIssue: " + msg.issue + "\nPlayer Id: " + msg.player + "\nTeam name: " + msg.troop.team.name);
    // }

    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected");
        MenuManager.ToggleLoadingScreen();
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
}