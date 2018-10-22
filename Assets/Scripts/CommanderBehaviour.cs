using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using System;
using Newtonsoft.Json;

public class CommanderBehaviour : MonoBehaviour
{
    void Start()
    {
        SetupServer();
    }

    public void SetupServer()
    {
        NetworkServer.Listen(4444);
        NetworkServer.RegisterHandler(MyMsgType.Command, OnServerReadyToBeginMessage);
        Debug.Log("Created server");
    }

    void OnServerReadyToBeginMessage(NetworkMessage netMsg)
    {
        string beginMessage = netMsg.ReadMessage<StringMessage>().value;
        Command msg = JsonConvert.DeserializeObject<Command>(beginMessage);
        Debug.Log("Server\nIssue: " + msg.issue + "\nPlayer Id: " + msg.player + "\nTroop size: " + msg.troop.units);
        msg = new Command();
        msg.issue = DateTime.Now;
        msg.player = 0;
        msg.troop = new Troop(20, new Team("rodrigo", 255, 255, 255, 255));
        netMsg.conn.Send(MyMsgType.Command, new StringMessage(JsonConvert.SerializeObject(msg)));
    }
}
