using UnityEngine;
using System.Collections;

public class Wizard : Player {

    void Update() {

        transform.position += new Vector3 (Input.GetAxis ("Controller2Horizontal"), 0, Input.GetAxis ("Controller2Vertical")) * moveSpeed * Time.deltaTime;
        
        if (Input.GetButton ("Controller2Attack")) {
            Debug.Log ("P2 attacking");
        }
        if (Input.GetButton ("Controller2Item")) {
            Debug.Log ("P2 using item");
        }
    }

}
