using UnityEngine;
using System.Collections;

public class Wizard : Player {

    void Update() {

        transform.position += new Vector3 (Input.GetAxis ("Controller2Horizontal"), 0, Input.GetAxis ("Controller2Vertical")) * moveSpeed * Time.deltaTime;

        if (Input.GetAxis ("Controller2Horizontal") != 0 || Input.GetAxis ("Controller2Vertical") != 0) {
            playerFacingDirection = new Vector3 (Input.GetAxis ("Controller2Horizontal"), 0, Input.GetAxis ("Controller2Vertical"));
            weaponAngle = Vector3.Angle (playerFacingDirection, Vector3.forward);
            if (playerFacingDirection.x < 0) {
                weaponAngle = -weaponAngle;
            }
        }

        eulerAngles = transform.eulerAngles;
        eulerAngles = new Vector3 (0, weaponAngle, 0);
        transform.eulerAngles = eulerAngles;

        if (Input.GetButtonDown ("Controller2Attack")) {
            //Debug.Log ("P2 attacking");
            Attack ();
        }
        if (Input.GetButtonDown ("Controller2Item")) {
            Debug.Log ("P2 using item");
        }
    }

}
