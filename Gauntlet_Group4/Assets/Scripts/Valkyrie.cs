using UnityEngine;
using System.Collections;

public class Valkyrie : Player {

    void Update() {
        transform.position += new Vector3 (Input.GetAxis ("Controller3Horizontal"), 0, Input.GetAxis ("Controller3Vertical")) * moveSpeed * Time.deltaTime;
        if (Input.GetAxis ("Controller3Horizontal") != 0) {
            Debug.Log (Input.GetAxis ("Controller3Horizontal"));
        }
        if (Input.GetButton ("Controller3Horizontal")) {
            Debug.Log ("Pressing controller buttons");
        }
        if (Input.GetButton ("Controller3Attack")) {
            Debug.Log ("P3 attacking");
        }
        if (Input.GetButton ("Controller3Item")) {
            Debug.Log ("P3 using item");
        }
    }

}
