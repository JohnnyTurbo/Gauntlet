using UnityEngine;
using System.Collections;

public class Ghost : Enemy {


    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<Player> ().ChangeHealth (-attackStrength);
            Destroy (gameObject);
        }
    }

}
