using UnityEngine;
using System.Collections;

public class Valkyrie : Player {

    void Update() {

        transform.position += new Vector3 (Input.GetAxis ("Controller3Horizontal"), 0, Input.GetAxis ("Controller3Vertical")) * moveSpeed * Time.deltaTime;

        if (Input.GetAxis ("Controller3Horizontal") != 0 || Input.GetAxis ("Controller3Vertical") != 0) {
            playerFacingDirection = new Vector3 (Input.GetAxis ("Controller3Horizontal"), 0, Input.GetAxis ("Controller3Vertical"));
            weaponAngle = Vector3.Angle (playerFacingDirection, Vector3.forward);
            if (playerFacingDirection.x < 0) {
                weaponAngle = -weaponAngle;
            }
        }

        eulerAngles = transform.eulerAngles;
        eulerAngles = new Vector3 (0, weaponAngle, 0);
        transform.eulerAngles = eulerAngles;

        if (Input.GetButtonDown ("Controller3Attack")) {
            //Debug.Log ("P3 attacking");
            Attack ();
        }
        if (Input.GetButtonDown ("Controller3Item")) {
            Debug.Log ("P3 using item");
        }
    }

}
