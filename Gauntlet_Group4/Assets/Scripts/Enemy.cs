using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int score;
    public float moveSpeed;
    public float attackSpeed;
    public int attackStrength;
    public int armor;
    public int health;
    public int magicResist;

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

    void Update() {
        if (target) {
            nmAgent.SetDestination (target.transform.position);
        }
    }

    public void DecrementHealth(int decHealthBy) {
        health -= decHealthBy;
        if (health <= 0) {
            Destroy (gameObject);
        }
    }

    void OnTriggerEnter(Collider col) {
        if (!hasTarget && col.gameObject.tag == "Player") {
            hasTarget = true;
            target = col.gameObject;
            mySpawner.ReopenIndex (spawnerIndex);
        }
    }

}
