using UnityEngine;
using System.Collections;

public class Warrior : Player {

    void Update() {

		transform.position += new Vector3(Input.GetAxis ("Controller1Horizontal"), 0, Input.GetAxis ("Controller1Vertical")) * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown ("Controller1Attack")) {
            Debug.Log ("P1 attacking");
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
