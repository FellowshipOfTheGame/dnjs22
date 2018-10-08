using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class Commander : NetworkBehaviour
{
    public class MyMsgType
    {
        public static short Hello = MsgType.Highest + 1;
    };

    public class HelloMessage : MessageBase
    {
        public string hello;
    }

    void Start()
    {
        SetupServer();
    }

    public void SetupServer()
    {
        NetworkServer.Listen(4444);
        NetworkServer.RegisterHandler(MyMsgType.Hello, OnServerReadyToBeginMessage);
        Debug.Log("Created server");
    }

    void OnServerReadyToBeginMessage(NetworkMessage netMsg)
    {
        var beginMessage = netMsg.ReadMessage<StringMessage>();
        Debug.Log("Server " + beginMessage.value);
        HelloMessage msg = new HelloMessage();
        msg.hello = "hero";
        netMsg.conn.Send(MyMsgType.Hello, msg);
    }
}
