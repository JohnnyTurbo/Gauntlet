using UnityEngine;
using System.Collections;

public class Warrior : Player {

    void Update() {
        transform.position += new Vector3(Input.GetAxis ("Controller1Horizontal"), 0, Input.GetAxis ("Controller1Vertical")) * moveSpeed * Time.deltaTime;
        if (Input.GetAxis ("Controller1Horizontal") != 0) {
            Debug.Log (Input.GetAxis ("Controller1Horizontal"));
        }
        if (Input.GetButton ("Controller1Horizontal")) {
            Debug.Log ("Pressing controller buttons");
        }
        if (Input.GetButton ("Controller1Attack")) {
            Debug.Log ("P1 attacking");
        }
        if (Input.GetButton ("Controller1Item")) {
            Debug.Log ("P1 using item");
        }
    }

}
