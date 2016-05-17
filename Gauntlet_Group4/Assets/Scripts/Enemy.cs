using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int score;
    public float moveSpeed;
    public float attackSpeed;
    public int attackStrength;
    public int health;
    public float distFromPlayer;

    public int spawnerIndex;
    public EnemySpawner mySpawner;

    protected NavMeshAgent nmAgent;
    protected GameObject target;
    protected bool hasTarget = false;

    void Awake() {
        nmAgent = gameObject.GetComponent<NavMeshAgent> ();
        if (!nmAgent) {
            Debug.LogError ("The GameObject " + gameObject.name + " has no NavMeshAgent component!");
        }
    }

    protected virtual void Update() {
        if (target) {
            if (distFromPlayer < Vector3.Distance (target.transform.position, transform.position)) {
                nmAgent.SetDestination (target.transform.position);
            }
            else {
                nmAgent.SetDestination (transform.position);
            }
        }
    }

    public void DecrementHealth(int decHealthBy, Player player) {
        health -= decHealthBy;
        if (health <= 0) {
            player.IncreaseScore (score);
            Destroy (gameObject);
        }
    }

    void OnTriggerEnter(Collider col) {
        if (!hasTarget && col.gameObject.tag == "Player") {
            RaycastHit hit;
            Physics.Linecast (gameObject.transform.position, col.transform.position, out hit);
            if (hit.transform.gameObject.tag == "Player") {
                hasTarget = true;
                target = col.gameObject;
                mySpawner.ReopenIndex (spawnerIndex);
            }
        }
    }

    void OnTriggerStay(Collider col) {
        if (!hasTarget && col.gameObject.tag == "Player") {
            RaycastHit hit;
            Physics.Linecast (gameObject.transform.position, col.transform.position, out hit);
            if (hit.transform.gameObject.tag == "Player") {
                hasTarget = true;
                target = col.gameObject;
                mySpawner.ReopenIndex (spawnerIndex);
            }
        }
    }

    protected virtual void Attack() {

    }

}
