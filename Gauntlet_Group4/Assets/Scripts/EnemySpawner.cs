using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemyType;
    public float timeBetweenSpawns;

    public bool[] locations = new bool[8];
    public bool[] isOpen = new bool[8];

    protected Vector3[] spawnLocations = new Vector3[] { new Vector3 (-1.5f, 0, 1.5f), new Vector3 (0, 0, 1.5f), new Vector3 (1.5f, 0, 1.5f), new Vector3 (-1.5f, 0, 0), new Vector3 (1.5f, 0, 0), new Vector3 (-1.5f, 0, -1.5f), new Vector3 (0, 0, -1.5f), new Vector3 (1.5f, 0, -1.5f) };

    

    void Awake() {
        for (int index = 0; index < locations.Length; index++) {
            isOpen[index] = locations[index];
        }
    }

    void Start() {
        StartCoroutine (SpawnEnemy ());
    }

    IEnumerator SpawnEnemy() {
        for (int index = 0; index < isOpen.Length; index++) {
            if (isOpen[index]) {
                GameObject newEnemy = Instantiate (enemyType, spawnLocations[index] + transform.position, Quaternion.identity) as GameObject;
                newEnemy.GetComponent<Enemy> ().spawnerIndex = index;
                newEnemy.GetComponent<Enemy> ().mySpawner = this;
                isOpen[index] = false;
                yield return new WaitForSeconds(timeBetweenSpawns);
            }
            yield return null;
        }
        StartCoroutine (SpawnEnemy ());
    }

    public void ReopenIndex(int indexToOpen) {
        isOpen[indexToOpen] = true;
    }
}
