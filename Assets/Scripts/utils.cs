using UnityEngine;
using System;
using UnityEngine.Networking;

public static class MyMsgType
{
    public static short MessageCommand = MsgType.Highest + 1;
    public static short CommandAddedSuccesfull = MsgType.Highest + 2;
    public static short BoughtSuccesfull = MsgType.Highest + 3;
    public static short AddedSuccesfull = MsgType.Highest + 4;

	public static short Login = MsgType.Highest + 5;
	public static short RegisterSuccessfull = MsgType.Highest + 6;
};

public class MessageCommand
{
    public int type;
    public DateTime issue;
    public Troop troop;
    public int buy;
    public string player;
    public int target;

	public string user;
    public int id;
	public string password = "42";
	public int team;
	public string lastLogin;
	public int money;
}

public class Command
{
    public DateTime issue;
    public Troop troop;
    public int cost;
    public string player;
    public int target;

	//public int
	public string user;
	public string password = "42";
	public NetworkMessage netMsg;
}