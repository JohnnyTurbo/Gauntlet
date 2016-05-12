using UnityEngine;
using System.Collections;

public class Elf : Player {

    void Update() {

        //transform.position += new Vector3 (Input.GetAxis ("Controller4Horizontal"), 0, Input.GetAxis ("Controller4Vertical")) * moveSpeed * Time.deltaTime;
		Vector3 test = new Vector3 (Input.GetAxis ("Controller4Horizontal"), 0, Input.GetAxis ("Controller4Vertical")) * moveSpeed;// * Time.deltaTime;
		Debug.Log (test.ToString());
		transform.Translate(test * Time.deltaTime, Space.World);
        if (Input.GetAxis ("Controller4Horizontal") != 0 || Input.GetAxis ("Controller4Vertical") != 0) {
            playerFacingDirection = new Vector3 (Input.GetAxis ("Controller4Horizontal"), 0, Input.GetAxis ("Controller4Vertical"));
            weaponAngle = Vector3.Angle (playerFacingDirection, Vector3.forward);
            if (playerFacingDirection.x < 0) {
                weaponAngle = -weaponAngle;
            }
        }

        eulerAngles = transform.eulerAngles;
        eulerAngles = new Vector3 (0, weaponAngle, 0);
        transform.eulerAngles = eulerAngles;

        if (Input.GetButtonDown ("Controller4Attack")) {
            //Debug.Log ("P4 attacking");
            Attack ();
        }
        if (Input.GetButtonDown ("Controller4Item")) {
            Debug.Log ("P4 using item");
        }
    }

}
