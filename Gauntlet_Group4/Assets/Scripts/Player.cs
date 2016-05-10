using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float moveSpeed;

	int health;
	int score;
	int potions;
	int keys;
	int armor;
	int magic;

	//TODO Weapon weapon;

	void Start(){
		GameController.instance.playersInGame.Add (this);
	}

	void Update(){
		//transform.position += new Vector3(Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")) * moveSpeed * Time.deltaTime;
	}

	virtual protected void Attack(){
		
	}

	void OnDestroy(){
		GameController.instance.playersInGame.Remove (this);
	}

}
