using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.Networking.NetworkSystem;

public class Army : MonoBehaviour
{
    public class MyMsgType
    {
        public static short Hello = MsgType.Highest + 1;
    };

    public class HelloMessage : MessageBase
    {
        public string hello;
    }

    NetworkClient myClient;
    //With the @ before the string, we can split a long string in many lines without getting errors
    private string json = @"{
		'hello':'world', 
		'foo':'bar', 
		'count':25
	}";

    void Start()
    {
        SetupClient();
    }

    public void SetupClient()
    {
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        myClient.RegisterHandler(MyMsgType.Hello, PrintReturn);
        myClient.Connect("127.0.0.1", 4444);
    }

    public void SetupLocalClient()
    {
        myClient = ClientScene.ConnectLocalServer();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
    }

    void PrintReturn(NetworkMessage netMsg)
    {
        var beginMessage = netMsg.ReadMessage<StringMessage>();
        Debug.Log("Client " + beginMessage.value);
    }

    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected");
        HelloMessage msg = new HelloMessage();
        msg.hello = json;
        myClient.Send(MyMsgType.Hello, msg);
    }
}