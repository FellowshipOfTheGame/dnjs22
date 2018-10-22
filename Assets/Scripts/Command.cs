using UnityEngine;
using System.Collections;

public class Command
{
	private System.DateTime start;
	private int duration;
	private int destiny;
	private int[] path;
	private int id;
	private int type;
	private int player;
	private Troop troop;

	public Command(System.DateTime start, int id, int type, int player, Troop troop, int destiny){
		this.start = start;
		this.id = id;
		this.type = type;
		this.player = player;
		this.troop = troop;
		this.destiny = destiny;
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

