using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public int attackStrength;
    public float attackSpeed;
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
                col.gameObject.GetComponent<Enemy> ().DecrementHealth(attackStrength, myPlayer);
                Destroy (gameObject);
                break;
            case "EnemySpawner":
                col.gameObject.GetComponent<EnemySpawner> ().DecrementHealth (attackStrength, myPlayer);
                Destroy (gameObject);
                break;
            case "EnemyShot":
                Destroy (col.gameObject);
                break;
            case "Wall":
                Destroy (gameObject);
                return;
            default:
                break;
        }
    }

}