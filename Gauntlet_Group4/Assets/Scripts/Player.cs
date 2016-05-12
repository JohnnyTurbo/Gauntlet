using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float moveSpeed;
	public GameObject WeaponPrefab;

	protected Vector3 playerFacingDirection;
    protected float weaponAngle;
    protected GameObject playerImage;
    protected Vector3 eulerAngles;

    int health;
	int score;
	int potions;
	int keys;
	int armor;
	int magic;

    void Awake() {
        playerImage = transform.FindChild ("PlayerIcon").gameObject;
    }

	void Start(){
		GameController.instance.playersInGame.Add (this);
        //playerFacingDirection = new Vector3(0,90,0);
	}

	virtual protected void Attack(){
        //float weaponAngle = Vector3.Angle (playerFacingDirection, Vector3.forward);
       
        GameObject newWeapon = GameObject.Instantiate (WeaponPrefab, transform.position, Quaternion.Euler(0,weaponAngle,0)) as GameObject;
		newWeapon.GetComponent<Weapon> ().myPlayer = this;
	}

	void OnDestroy(){
		GameController.instance.playersInGame.Remove (this);
	}

}
