using UnityEngine;
using System.Collections;

public class Warrior : Player {

    

    void Update() {

		transform.position += new Vector3(Input.GetAxis ("Controller1Horizontal"), 0, Input.GetAxis ("Controller1Vertical")) * moveSpeed * Time.deltaTime;
        if (Input.GetAxis ("Controller1Horizontal") != 0 || Input.GetAxis ("Controller1Vertical") != 0) {
            playerFacingDirection = new Vector3 (Input.GetAxis ("Controller1Horizontal"), 0, Input.GetAxis ("Controller1Vertical"));
            weaponAngle = Vector3.Angle (playerFacingDirection, Vector3.forward);
            if (playerFacingDirection.x < 0) {
                weaponAngle = -weaponAngle;
            }
        }

        eulerAngles = transform.eulerAngles;
        eulerAngles = new Vector3 (0, weaponAngle, 0);
        transform.eulerAngles = eulerAngles;

        if (Input.GetButtonDown ("Controller1Attack")) {
            //Debug.Log ("P1 attacking");
			Attack();
        }
        if (Input.GetButtonDown ("Controller1Item")) {
            Debug.Log ("P1 using item");
        }
    }

	protected override void Attack ()
	{
		base.Attack ();
	}

}
