using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSpawner : MonoBehaviour {

    public static PlayerSpawner instance;

    public readonly List<Vector3> spawnSpots = new List<Vector3> () { new Vector3 (-1.5f, 0, 1.5f), new Vector3 (1.5f, 0, 1.5f) , new Vector3 (-1.5f, 0, -1.5f) , new Vector3 (1.5f, 0, -1.5f) };

    void Awake() {
        instance = this;
    }

    void Start() {
        StartCoroutine (SpawnDelay ());
    }

    IEnumerator SpawnDelay() {
        yield return new WaitForSeconds (0.0001f);
        GameController.instance.BeginLevel ();
    }
}
