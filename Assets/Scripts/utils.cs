using UnityEngine;
using System;
using UnityEngine.Networking;

public static class MyMsgType
{
    public static short Command = MsgType.Highest + 1;
};

public class Command
{
    public DateTime issue;
    public int player;
    public Troop troop;
}

public class Troop
{
    public int units;
    public Team team;

    public Troop(int units, Team team)
    {
        this.units = units;
        this.team = team;
    }
}

public class Team
{
    public string name;
    public Vector4 color;

    public Team(string name, int r, int g, int b, int a)
    {
        this.name = name;
        this.color = new Vector4(r, g, b, a);
    }
}