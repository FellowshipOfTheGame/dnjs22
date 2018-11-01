using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseController{

	private string connection = "http://localhost/dnjs22/Connection.php";
	private string login = "http://localhost/dnjs22/Login.php?";
	private string registerPlayer = "http://localhost/dnjs22/RegisterPlayer.php?";
	private string playerExists = "http://localhost/dnjs22/PlayerExists.php?";
	private string registerTeam = "http://localhost/dnjs22/RegisterTeam.php?";
	private string registerTower = "http://localhost/dnjs22/RegisterTower.php?";
	private string registerEdge = "http://localhost/dnjs22/RegisterEdge.php?";
	private string updateEdge = "http://localhost/dnjs22/UpdateEdge.php?";
	private string updateTower = "http://localhost/dnjs22/UpdateTower.php?";
	private string getTower = "http://localhost/dnjs22/GetTower.php?";

	//public static DatabaseController instance = null;

	public bool isRunningLogin = false, isLoginSuccessfull = false;
	public int idReturn = -1, teamReturn, moneyReturn;
	public DateTime lastLoginReturn;


	public bool isRunningPlayerExists = false;
	public bool playerExistsReturn = false;

	public bool isRunningRegisterPlayer = false;

	/*
	public Coroutine coroutine { get; private set; }
	public object result;
	private IEnumerator target;


	void Awake(){
		/*
		if (instance == null)
			instance = this;
		else if (instance != this) 
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

	}*/

	// Use this for initialization
	void Start () {
		/*
		StartCoroutine (RegisterPlayer ("Gabriel", "123"));
		StartCoroutine (Login ("Gabriel", "123"));
		StartCoroutine (PlayerExists ("Gabriel"));
		StartCoroutine (RegisterTeam ("Team2", "Red"));
		//StartCoroutine (RegisterTower (-1, -1));
		//StartCoroutine (RegisterEdge (1, 1, 3));
		StartCoroutine (UpdateEdge (1, 1, 5));
		StartCoroutine (UpdateTower (1, 1, 20));
		StartCoroutine (GetTower (1));*/

		//CommandDB ();
	}
	/*
	public DatabaseController(MonoBehaviour owner, IEnumerator target){
		this.target = target;
		this.coroutine = owner.StartCoroutine (Run ());
	}

	private IEnumerator Run(){
		while (target.MoveNext ()) {
			result = target.Current;
			yield return result;
		}
	}

	private IEnumerator CommandDB(){
		DatabaseController db = new DatabaseController (this, RegisterPlayer ("Edson", "123"));
		yield return db.coroutine;

		Debug.Log ("At CommanderBehaviour: id = " + db.result);
	}
	*/

	public IEnumerator Login(string user, string password){
		DateTime dt = DateTime.Now;
		string strDate = String.Format("{0:yyyy/M/d HH:mm:ss}", dt);

		// Post message
		isRunningLogin = true;

		string url = login + "user=" + WWW.EscapeURL (user) + "&pswd=" + WWW.EscapeURL (password) + "&lastLogin=" + WWW.EscapeURL(strDate);
		WWW wLogin = new WWW (url);
		yield return wLogin;

		if (wLogin.error != null)	// Some error
			Debug.Log ("Error at login");
		else {
			if (wLogin.text != "") {
				Debug.Log (wLogin.text);
				string[] result = wLogin.text.Split (new string[] {"|"}, StringSplitOptions.None);

				//Get datas
				int.TryParse (result [0], out idReturn);
				//DateTime lastLogin;
				/*
				if(result[1] == "")
					lastLoginReturn = DateTime.Now;
				else*/
					lastLoginReturn = Convert.ToDateTime (result [1]);
				int.TryParse (result [2], out moneyReturn);
				string playerPassword = result [3];
				int.TryParse (result [4], out teamReturn);
				string playerUser = result [5];

				//TODO Update lastLogin value
				//TODO Send player datas to client
				//idReturn = id;
				isLoginSuccessfull = true;
				isRunningLogin = false;
				//Debug.Log ("id = " + id + "lastLogin = " + lastLogin.ToString () + "money = " + money + "user = " + playerUser);

				//yield return "id = " + id;
			} else // null result
				Debug.Log ("Player not found.");
		}
		Debug.Log ("Exit");
		isRunningLogin = false;
	}

	public IEnumerator RegisterPlayer(string user, string password){
		isRunningRegisterPlayer = true;
		DateTime dt = DateTime.Now;
		string strDate = String.Format("{0:yyyy/M/d HH:mm:ss}", dt);
		int team = 1;
		//TODO Allocate player to a team
		string url = registerPlayer + "user=" + WWW.EscapeURL(user) + "&pswd=" + WWW.EscapeURL (password) + "&lastLogin=" 
			+ WWW.EscapeURL(strDate);
		WWW wRegister = new WWW (url);
		yield return wRegister;

		if (wRegister.error != null)
			Debug.Log ("Error at register.");
		else {
			if (wRegister.text == "Success") {
				teamReturn = team;
				moneyReturn = 0;
				lastLoginReturn = dt;
				Debug.Log ("Register successfull");
			} else {
				//Debug.Log ("Error on DB.");
				Debug.Log("Possibly success. Check database.");
			}
		}
		isRunningRegisterPlayer = false;
	}

	public IEnumerator PlayerExists(string user){
		isRunningPlayerExists = true;
		string url = playerExists + "user=" + WWW.EscapeURL (user);
		WWW wPlayerExists = new WWW (url);
		yield return wPlayerExists;

		if (wPlayerExists.error != null)
			Debug.Log ("Error at request.");
		else {
			if (wPlayerExists.text == "True") {
				playerExistsReturn = true;
				Debug.Log ("Player exists");
			} else {
				playerExistsReturn = false;
				Debug.Log ("Player doesn't exist");
			}
		}
		isRunningPlayerExists = false;
	}

	public IEnumerator RegisterTeam(string name, string color){
		string url = registerTeam + "name=" + WWW.EscapeURL (name) + "&color=" + WWW.EscapeURL (color);
		WWW wRegisterTeam = new WWW (url);
		yield return wRegisterTeam;

		if (wRegisterTeam.error != null)
			Debug.Log ("Error at register request.");
		else {
			if (wRegisterTeam.text == "Success")
				Debug.Log ("Register successfull");
			else
				Debug.Log ("Possibly success. Check database.");
		}
	}

	//If team id == -1, the tower doesn't have an owner team. 
	// If unit == -1, the tower starts with 0 units.
	public IEnumerator RegisterTower(int team, int unit){
		string strTeam = team.ToString();
		string strUnit = unit.ToString();

		string url = registerTower + "team=" + WWW.EscapeURL (strTeam) + "&unit=" + WWW.EscapeURL (strUnit);
		WWW wRegisterTower = new WWW (url);
		yield return wRegisterTower;

		if (wRegisterTower.error != null)
			Debug.Log ("Error at register request.");
		else {
			if (wRegisterTower.text == "Success")
				Debug.Log ("Register successfull");
			else
				Debug.Log ("Possibly success. Check database.");
		}
	}

	public IEnumerator RegisterEdge(int firstSource, int secondSource, int cost){
		string strFirstSource = firstSource.ToString();
		string strSecondSource = secondSource.ToString();
		string strCost = cost.ToString ();

		string url = registerEdge + "first=" + WWW.EscapeURL (strFirstSource) + "&scnd=" + WWW.EscapeURL (strSecondSource)
		             + "&cost=" + WWW.EscapeURL (strCost);
		WWW wRegisterEdge = new WWW (url);
		yield return wRegisterEdge;

		if (wRegisterEdge.error != null)
			Debug.Log ("Error at register request.");
		else {
			if (wRegisterEdge.text == "Success")
				Debug.Log ("Register successfull");
			else
				Debug.Log ("Possibly success. Check database.");
		}
	}

	public IEnumerator UpdateEdge(int firstSource, int secondSource, int cost){
		string strFirstSource = firstSource.ToString();
		string strSecondSource = secondSource.ToString();
		string strCost = cost.ToString ();

		string url = updateEdge + "first=" + WWW.EscapeURL (strFirstSource) + "&scnd=" + WWW.EscapeURL (strSecondSource)
			+ "&cost=" + WWW.EscapeURL (strCost);
		WWW wUpdateEdge = new WWW (url);
		yield return wUpdateEdge;

		if (wUpdateEdge.error != null)
			Debug.Log ("Error at register request.");
		else {
			if (wUpdateEdge.text == "Success")
				Debug.Log ("Register successfull");
			else
				Debug.Log ("Possibly success. Check database.");
		}
	}

	private IEnumerator UpdateTower(int id, int team, int unit){
		string strId = id.ToString ();
		string strTeam = team.ToString();
		string strUnit = unit.ToString();

		string url = updateTower + "id=" + WWW.EscapeURL(strId) + "&team=" + WWW.EscapeURL (strTeam) + "&unit=" + WWW.EscapeURL (strUnit);
		WWW wUpdateTower = new WWW (url);
		yield return wUpdateTower;

		if (wUpdateTower.error != null)
			Debug.Log ("Error at register request.");
		else {
			if (wUpdateTower.text == "Success")
				Debug.Log ("Register successfull");
			else
				Debug.Log ("Possibly success. Check database.");
		}
	}

	private IEnumerator GetTower(int id){
		string strId = id.ToString ();

		string url = getTower + "id=" + WWW.EscapeURL(strId);
		WWW wGetTower = new WWW (url);
		yield return wGetTower;

		if (wGetTower.error != null)
			Debug.Log ("Error at get request.");
		else {
			if (wGetTower.text != "") {
				string[] result = wGetTower.text.Split (new string[] {"|"}, StringSplitOptions.None);
				int team = 0, unit = 0;

				int.TryParse (result [0], out team);
				int.TryParse(result[1], out unit);

				Debug.Log ("id=" + id + " has: team=" + team + " unit=" + unit);
			}
			else
				Debug.Log ("Possibly success. Check database.");
		}
	}
}
