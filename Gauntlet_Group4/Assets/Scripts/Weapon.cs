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

    void Start() {
        GetComponent<Rigidbody> ().AddRelativeForce (new Vector3 (0, 0, 1) * attackSpeed);
    }

    void OnCollisionEnter(Collision col) {
        switch (col.gameObject.tag) {
            case "Enemy":
                col.gameObject.GetComponent<Enemy> ().DecrementHealth(attackStrength);
                Destroy (gameObject);
                break;
            case "EnemySpawner":
                Destroy (gameObject);
                break;
            case "Wall":
                Destroy (gameObject);
                return;
            default:
                break;
        }
    }

}