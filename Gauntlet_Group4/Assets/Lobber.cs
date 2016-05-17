using UnityEngine;
using System.Collections;

public class Lobber : Enemy {

    public GameObject weapon;
    bool calledOnce = false;
    GameObject newLobShot;
    public float attackDelay;

    protected override void Update() {
        base.Update ();
        if (!calledOnce && hasTarget) {
            calledOnce = true;
            StartCoroutine (Lob ());
        }
    }

    IEnumerator Lob() {
        yield return new WaitForSeconds (attackDelay);
        newLobShot = Instantiate (weapon, transform.position, Quaternion.identity) as GameObject;
        newLobShot.GetComponent<Rigidbody> ().AddForce ((target.transform.position - transform.position).normalized * attackSpeed);
        newLobShot.GetComponent<EnemyShot> ().shotStrength = attackStrength;
        StartCoroutine (Lob ());
    }

}
