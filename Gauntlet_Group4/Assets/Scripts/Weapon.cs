using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public int attackStrength;
	public float attackSpeed;
	public bool isMagic;
	public Player myPlayer;

	/*
	void Update(){
		transform.Translate (new Vector3 (0, 0, 1) * attackSpeed * Time.deltaTime);
	}
	*/

	void Start(){
		GetComponent<Rigidbody> ().AddRelativeForce (new Vector3(0,0,1) * attackSpeed);
	}

	void OnCollisionEnter(Collision col){
		Debug.Log (col.gameObject.name);
		switch (col.gameObject.tag) {
		case "Enemy":
			break;
		case "EnemySpawner":
			break;
		case "Wall":
			Debug.Log("Destroying this gameobject");
			Destroy(this.gameObject);
			return;
		default:
			break;
		}
	}

}