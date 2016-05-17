using UnityEngine;
using System.Collections;

public class ClubController : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            other.gameObject.GetComponent<Player> ().ChangeHealth (-transform.parent.gameObject.GetComponent<Enemy> ().attackStrength);
        }
    }

    void Update() {
        transform.RotateAround (transform.parent.position, Vector3.up, transform.parent.gameObject.GetComponent<Enemy> ().attackSpeed);
    }
}
