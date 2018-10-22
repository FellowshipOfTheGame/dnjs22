using UnityEngine;
using System.Collections;

public class Team
{
	#region Attributes

	private string name;
	private Color color;
	private int id;
	private int mainBase;

	#endregion

	public Team(string name, Color color, int id, int mainBase){
		this.name = name;
		this.Color = color;
		this.id = id;
		this.mainBase = mainBase;
	}

	#region Getters and Setters

	public string Name{
		get{
			return name;
		}

		set{
			name = value;
		}
	}

	public Color Color{
		get{
			return color; 
		}

		set{
			color = value;
		}
	}

	public int Id{
		get{
			return id;
		}

		set{
			id = value;
		}
	}

	public Vector2 MainBase{
		get{
			return mainBase;
		}

		set{
			mainBase = value;
		}
	}

	#endregion

	#region Methods

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	#endregion
}

