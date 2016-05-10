using UnityEngine;
using System.Collections;

public class Valkyrie : Player {

    void Update() {

        transform.position += new Vector3 (Input.GetAxis ("Controller3Horizontal"), 0, Input.GetAxis ("Controller3Vertical")) * moveSpeed * Time.deltaTime;
        
        if (Input.GetButton ("Controller3Attack")) {
            Debug.Log ("P3 attacking");
        }
        if (Input.GetButton ("Controller3Item")) {
            Debug.Log ("P3 using item");
        }
    }

}
