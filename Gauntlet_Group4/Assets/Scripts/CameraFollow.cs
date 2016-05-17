using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float cameraMoveSpeed;
	public float minCamSize;
	public float maxCamSize;
	public float sizeCompensation;

    float xCompensation = 0f;
    float calculatedSize;
    Vector3 calculatedPos;
	float camSize;

	void Awake(){

    }

	void Update () {
        calculatedPos = CalculatePosition ();
        calculatedSize = CalculateSize ();
        xCompensation = calculatedSize / 2;
		transform.position = Vector3.Lerp(transform.position, calculatedPos, Time.deltaTime * cameraMoveSpeed);
		GetComponent<Camera> ().orthographicSize = Mathf.Lerp(GetComponent<Camera> ().orthographicSize, calculatedSize, Time.deltaTime * cameraMoveSpeed);
	}

	Vector3 CalculatePosition(){
		float x = 0, z = 0;
		foreach (Player player in GameController.instance.playersInGame) {
			x += player.transform.position.x;
			z += player.transform.position.z;
		}
		x /= GameController.instance.playersInGame.Count;
		z /= GameController.instance.playersInGame.Count;

		return new Vector3 (x + xCompensation, transform.position.y, z);
	}

	float CalculateSize(){
		float greatestDistance = 0;
		float distFromCamToPlayer = 0;
		foreach (Player player in GameController.instance.playersInGame){
			distFromCamToPlayer = Vector3.Distance (new Vector3(player.transform.position.x, 0, player.transform.position.z), new Vector3(transform.position.x - xCompensation, 0, transform.position.z));
			if (greatestDistance < distFromCamToPlayer){
				greatestDistance = distFromCamToPlayer;
			}
		}
		if (greatestDistance <= minCamSize) {
            return minCamSize + (sizeCompensation * (minCamSize/maxCamSize));
		} 
		else if (greatestDistance >= maxCamSize) {
            return maxCamSize + sizeCompensation;
		} 
		else {
            return greatestDistance + (sizeCompensation * (greatestDistance/maxCamSize));
		}
	}
}
