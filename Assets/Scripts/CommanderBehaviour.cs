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

		StartCoroutine (RegisterPLayer ("Rose", "111"));

		DatabaseController db = new DatabaseController ();
		StartCoroutine (db.PlayerExists ("Jeff"));
		StartCoroutine (db.RegisterPlayer ("Kamzu", "333"));
		StartCoroutine(db.Login("Kamzu", "333"));
    }

	private IEnumerator RegisterPLayer(string user, string password){
		DatabaseController db = new DatabaseController ();
		StartCoroutine (db.PlayerExists (user));
		while (db.isRunningPlayerExists)
			yield return null;
		if(!db.playerExistsReturn){
			StartCoroutine (db.RegisterPlayer(user, password));
		}
	}

	private IEnumerator Login(string user, string password, NetworkMessage netMsg){
		DatabaseController db = new DatabaseController ();
		StartCoroutine (db.Login (user, password));
		while (db.isRunningLogin)
			yield return null;
		if (db.isLoginSuccessfull) {
			MessageCommand msg = new MessageCommand ();
			msg.player = db.idReturn;
			msg.password = password;
			msg.team = db.teamReturn;
			msg.money = db.moneyReturn;
			msg.lastLogin = String.Format("{0:yyyy/M/d HH:mm:ss}", db.lastLoginReturn);
			netMsg.conn.Send (MyMsgType.LoginSuccessfull, new StringMessage (JsonConvert.SerializeObject (msg)));
		}
	}
	/*
	private FinishLogin(string user, string password){

	}
	*/
	private IEnumerator Command(){
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
				if (onHold [i].user != null && onHold [i].user != "" && onHold [i].password != null && onHold [i].password != "") {
					StartCoroutine(Login (onHold [i].user, onHold [i].password, onHold[i].netMsg));
				}

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

	/*
	int Login(MessageCommand msg){

	}
	*/
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

		if (msg.type == 0) {
			Command hold = new Command ();
			hold.issue = msg.issue;
			hold.player = msg.player;
			hold.target = msg.target;
			hold.troop = msg.troop;

			// Check command cost
			hold.cost = 10;

			if (PutOnHold (hold) == MyMsgType.CommandAddedSuccesfull) {
				netMsg.conn.Send (MyMsgType.AddedSuccesfull, new IntegerMessage (hold.cost));
			}
		} else if (msg.type == 1) {
			if (BuyTroop (msg) == MyMsgType.CommandAddedSuccesfull) {
				// Return player money
				netMsg.conn.Send (MyMsgType.BoughtSuccesfull, new IntegerMessage (30));
			}
		} else if (msg.type == 2) {
			Command hold = new Command ();
			hold.player = msg.player;
			hold.password = msg.password;
			hold.netMsg = netMsg;

			if(PutOnHold (hold) == MyMsgType.CommandAddedSuccesfull){
				netMsg.conn.Send (MyMsgType.LoginSuccessfull, new IntegerMessage (1));
			}
		}
    }
}
