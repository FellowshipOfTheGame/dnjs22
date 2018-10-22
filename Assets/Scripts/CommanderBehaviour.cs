using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using System;
using Newtonsoft.Json;

public class CommanderBehaviour : MonoBehaviour
{
    [SerializeField] private int checkCommands = 5;
    private List<Command> onHold;
    private double timer = 0;
    private Map map;

    void Start()
    {
        onHold = new List<Command>();
        SetupServer();
        //map = new Map();
    }

    void Update()
    {
        if (timer >= checkCommands)
        {
            for (int i = onHold.Count - 1; i >= 0; i--)
            {
                if (DateTime.Now >= onHold[i].issue.AddSeconds(onHold[i].cost))
                {
                    // Run command
                    Debug.Log("Rodou o comando");
                    onHold.RemoveAt(i);
                }
                else
                {
                    Debug.Log("Não rodou");
                }
            }
            timer -= checkCommands;
        }
        timer += Time.deltaTime;
    }

    int PutOnHold(MessageCommand cmd)
    {
        // Verify message command
        // Return error

        Command hold = new Command();
        hold.issue = cmd.issue;
        hold.player = cmd.player;
        hold.target = cmd.target;
        hold.troop = cmd.troop;

        // Check command cost
        hold.cost = 10f;

        Debug.Log(hold.issue);

        onHold.Add(hold);

        return MyMsgType.CommandAddedSuccesfull;
    }

    public void SetupServer()
    {
        NetworkServer.Listen(4444);
        NetworkServer.RegisterHandler(MyMsgType.MessageCommand, OnServerReadyToBeginMessage);
        Debug.Log("Created server");
    }

    void OnServerReadyToBeginMessage(NetworkMessage netMsg)
    {
        string beginMessage = netMsg.ReadMessage<StringMessage>().value;
        MessageCommand msg = JsonConvert.DeserializeObject<MessageCommand>(beginMessage);

        if (PutOnHold(msg) == MyMsgType.CommandAddedSuccesfull)
        {
            Debug.Log("Server\nIssue: " + msg.issue + "\nPlayer Id: " + msg.player + "\nTroop size: " + msg.troop.Units);
            // msg = new MessageCommand();
            // msg.issue = DateTime.Now;
            // msg.player = 0;
            // msg.troop = new Troop(20, new Team("rodrigo", 255, 255, 255, 255));
            // netMsg.conn.Send(MyMsgType.MessageCommand, new StringMessage(JsonConvert.SerializeObject(msg)));
        }
    }
}
