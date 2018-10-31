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

	//public GameObject databaseController;

	/*
	void Awake(){
		/*
		if (DatabaseController.instance == null)
			Instantiate (databaseController);
		
	}*/

    void Start()
    {
        onHold = new List<Command>();

        int[,] dist = new int[,] {
            { 0, 0, 1 },
            { 1, 0, 1 },
            { 0, 1, 0 }
        };

        Tower[] towers = new Tower[] {
            new Tower(),
            new Tower(),
            new Tower()
        };

        Region[] regions = new Region[] {
            new Region()
        };

        map = new Map(dist, towers, regions);
        SetupServer();

		StartCoroutine(Command ());
    }

	IEnumerator Command(){
		DatabaseController db = new DatabaseController ();
		Debug.Log ("Instantiated at commanderbehaviour");
		int id = 0;
		Debug.Log ("id = 0 at commanderbehaviour");
		StartCoroutine (db.Login("Edson", "123"));
		//StartCoroutine (Command (db));
		Debug.Log ("Started coroutine at commanderbehaviour");
		while (db.isRunningLogin) {
			yield return null;
			Debug.Log ("Loop waiting at commanderbehaviour");
		}
		id = db.idReturn;
		Debug.Log ("id at commanderbehaviour = " + id);
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

    int PutOnHold(Command cmd)
    {
        // Verify message command
        // Return error

        onHold.Add(cmd);

        return MyMsgType.CommandAddedSuccesfull;
    }

    int BuyTroop(MessageCommand msg)
    {
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

        if (msg.type == 0)
        {
            Command hold = new Command();
            hold.issue = msg.issue;
            hold.player = msg.player;
            hold.target = msg.target;
            hold.troop = msg.troop;

            // Check command cost
            hold.cost = 10;

            if (PutOnHold(hold) == MyMsgType.CommandAddedSuccesfull)
            {
                netMsg.conn.Send(MyMsgType.AddedSuccesfull, new IntegerMessage(hold.cost));
            }
        }
        else if (msg.type == 1)
        {
            if (BuyTroop(msg) == MyMsgType.CommandAddedSuccesfull)
            {
                // Return player money
                netMsg.conn.Send(MyMsgType.BoughtSuccesfull, new IntegerMessage(30));
            }
        }

    }
}
