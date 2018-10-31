using UnityEngine;
using System;
using UnityEngine.Networking;

public static class MyMsgType
{
    public static short MessageCommand = MsgType.Highest + 1;
    public static short CommandAddedSuccesfull = MsgType.Highest + 2;
    public static short BoughtSuccesfull = MsgType.Highest + 3;
    public static short AddedSuccesfull = MsgType.Highest + 4;

	public static short LoginSuccessfull = MsgType.Highest + 5;
	public static short RegisterSuccessfull = MsgType.Highest + 6;
};

public class MessageCommand
{
    public int type;
    public DateTime issue;
    public Troop troop;
    public int buy;
    public int player;
    public int target;

	public string user;
	public string password;
}

public class Command
{
    public DateTime issue;
    public Troop troop;
    public int cost;
    public int player;
    public int target;

	public string user;
	public string password;
}