using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float moveSpeed;
	public GameObject WeaponPrefab;

	protected Vector3 playerFacingDirection;
    protected float weaponAngle;
    protected GameObject playerImage;
    protected Vector3 eulerAngles;

    protected string horizontalInput, verticalInput, attackInput, itemInput;

    protected int health;
	protected int score;
    protected int potions;
    protected int keys;
    protected int armor;
    protected int magic;

    void Awake() {
        playerImage = transform.FindChild ("PlayerIcon").gameObject;
    }

	void Start(){
		GameController.instance.playersInGame.Add (this);
        //playerFacingDirection = new Vector3(0,90,0);
	}

    void Update() {

        GetComponent<Rigidbody> ().AddForce (new Vector3 (Input.GetAxis (horizontalInput), 0, Input.GetAxis (verticalInput)).normalized * moveSpeed);

        if (Input.GetAxis (horizontalInput) != 0 || Input.GetAxis (verticalInput) != 0) {
            playerFacingDirection = new Vector3 (Input.GetAxis (horizontalInput), 0, Input.GetAxis (verticalInput));
            weaponAngle = Vector3.Angle (playerFacingDirection, Vector3.forward);
            if (playerFacingDirection.x < 0) {
                weaponAngle = -weaponAngle;
            }
        }

        eulerAngles = transform.eulerAngles;
        eulerAngles = new Vector3 (0, weaponAngle, 0);
        transform.eulerAngles = eulerAngles;

        if (Input.GetButtonDown (attackInput)) {
            //Debug.Log ("P1 attacking");
            Attack ();
        }
        if (Input.GetButtonDown (itemInput)) {
            Debug.Log ("Player using item");
        }
    }

    void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag) {
            case "Chest":
                IncreaseScore (100);
                Destroy (other.gameObject);
                break;
            case "Door":
                if (this.keys > 0) {
                    ChangeNumKeys (-1);
                    Destroy (other.gameObject);
                }
                break;
            case "Key":
                ChangeNumKeys (1);
                Destroy (other.gameObject);
                break;
            case "Exit":
                break;
            case "Food":
                ChangeHealth (100);
                Destroy (other.gameObject);
                break;
            case "Potion":
                ChangePotions (1);
                Destroy (other.gameObject);
                break;
            default:
                return;
        }
    }

    virtual protected void Attack(){
        //float weaponAngle = Vector3.Angle (playerFacingDirection, Vector3.forward);
        GameObject newWeapon = GameObject.Instantiate (WeaponPrefab, transform.position, Quaternion.Euler(0,weaponAngle,0)) as GameObject;
		newWeapon.GetComponent<Weapon> ().myPlayer = this;
	}

	void OnDestroy(){
		GameController.instance.playersInGame.Remove (this);
	}

	public virtual void IncreaseScore(int newScore){
        score += newScore;
	}

    public virtual void ChangeHealth(int numHealth) {
        health += numHealth;
    }

    public virtual void ChangeNumKeys(int numKeys) {
        keys += numKeys;
    }

    public virtual void ChangePotions(int numPotions) {
        potions += numPotions;
    }

}
