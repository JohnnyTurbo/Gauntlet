using UnityEngine;
using System.Collections;

public class EnemyShot : MonoBehaviour {

    public int shotStrength;

    void OnCollisionEnter(Collision col) {
        switch (col.gameObject.tag) {
            case "Player":
                col.gameObject.GetComponent<Player> ().ChangeHealth (-shotStrength);
                Destroy (gameObject);
                break;
            case "Wall":
                Destroy (gameObject);
                break;
        }
    }

}
