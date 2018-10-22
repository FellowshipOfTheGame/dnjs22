using UnityEngine;
using System.Collections;

public class Troop
{
	private int units;
	private Team team;

	public Troop(int units, Team team){
		this.units = units;
		this.team = team;
	}

	public int Units{
		get{
			return units;
		}

		set{ 
			units = value;
		}
	}

	public Team Team{
		get{
			return team;
		}

		set{ 
			team = value;
		}
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

