using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public static GameController instance;

	public List<Player> playersInGame;

	void Awake(){
		playersInGame = new List<Player> ();
		instance = this;
	}

}
