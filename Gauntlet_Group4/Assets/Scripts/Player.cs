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

	virtual protected void Attack(){

	}

	void Update(){
		transform.position += new Vector3(Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0) * moveSpeed * Time.deltaTime;
	}
}
