using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Valkyrie : Player {

    public static Valkyrie instance;

    void Awake() {
        DontDestroyOnLoad (transform.gameObject);
        instance = this;
        GameController.instance.valkyrieJoinText.SetActive (false);
        GameController.instance.valkyrieSpawned = true;
        horizontalInput = "Controller3Horizontal";
        verticalInput = "Controller3Vertical";
        attackInput = "Controller3Attack";
        itemInput = "Controller3Item";
        ChangeHealth (1000);
        StartCoroutine (DecrementHealthEachSecond ());
    }

    public override void IncreaseScore(int newScore) {
        base.IncreaseScore (newScore);
        GameController.instance.valkyrieScoretext.text = "Score: " + score;
    }

    public override void ChangeHealth(int numHealth) {
        base.ChangeHealth (numHealth);
        GameController.instance.valkyrieHealthtext.text = "Health: " + health;
    }

    public override void ChangeNumKeys(int numKeys) {
        base.ChangeNumKeys (numKeys);
        GameController.instance.valkyrieKeystext.text = "Keys: " + keys;
    }

    public override void ChangePotions(int numPotions) {
        base.ChangePotions (numPotions);
        GameController.instance.valkyriePotionstext.text = "Potions: " + potions;
    }

    void OnDestroy() {
        GameController.instance.playersInGame.Remove (this);
        GameController.instance.valkyrieJoinText.SetActive (true);
        GameController.instance.valkyrieJoinText.transform.FindChild ("Panel").FindChild ("Text").GetComponent<Text> ().text = "Defeated!";
    }

    IEnumerator DecrementHealthEachSecond() {
        yield return new WaitForSeconds (1f);
        ChangeHealth (-1);
        StartCoroutine (DecrementHealthEachSecond ());
    }
}
