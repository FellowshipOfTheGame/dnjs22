using UnityEngine;
using System;
using UnityEngine.Networking;

public static class MyMsgType
{
    public static short MessageCommand = MsgType.Highest + 1;
    public static short CommandAddedSuccesfull = MsgType.Highest + 1;
};

public class MessageCommand
{
    public DateTime issue;
    public Troop troop;
    public int player;
    public int target;
}

public class Command
{
    public DateTime issue;
    public double cost;
    public Troop troop;
    public int player;
    public int target;
}