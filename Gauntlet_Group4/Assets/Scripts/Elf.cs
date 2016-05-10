using UnityEngine;
using System.Collections;

public class Elf : Player {

    void Update() {

        transform.position += new Vector3 (Input.GetAxis ("Controller4Horizontal"), 0, Input.GetAxis ("Controller4Vertical")) * moveSpeed * Time.deltaTime;
		
        if (Input.GetButton ("Controller4Attack")) {
            Debug.Log ("P4 attacking");
        }
        if (Input.GetButton ("Controller4Item")) {
            Debug.Log ("P4 using item");
        }
    }

}
