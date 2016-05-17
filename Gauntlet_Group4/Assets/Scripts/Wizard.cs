using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Wizard : Player {

    public static Wizard instance;

    void Awake() {
        DontDestroyOnLoad (transform.gameObject);
        instance = this;
        GameController.instance.wizardJoinText.SetActive (false);
        GameController.instance.wizardSpawned = true;
        horizontalInput = "Controller2Horizontal";
        verticalInput = "Controller2Vertical";
        attackInput = "Controller2Attack";
        itemInput = "Controller2Item";
        ChangeHealth (1000);
        StartCoroutine (DecrementHealthEachSecond ());
    }

    public override void IncreaseScore(int newScore) {
        base.IncreaseScore (newScore);
        GameController.instance.wizardScoretext.text = "Score: " + score;
    }

    public override void ChangeHealth(int numHealth) {
        base.ChangeHealth (numHealth);
        GameController.instance.wizardHealthtext.text = "Health: " + health;
    }

    public override void ChangeNumKeys(int numKeys) {
        base.ChangeNumKeys (numKeys);
        GameController.instance.wizardKeystext.text = "Keys: " + keys;
    }

    public override void ChangePotions(int numPotions) {
        base.ChangePotions (numPotions);
        GameController.instance.wizardPotionstext.text = "Potions: " + potions;
    }

    void OnDestroy() {
        GameController.instance.playersInGame.Remove (this);
        GameController.instance.wizardJoinText.SetActive (true);
        GameController.instance.wizardJoinText.transform.FindChild ("Panel").FindChild ("Text").GetComponent<Text> ().text = "Defeated!";
    }

    IEnumerator DecrementHealthEachSecond() {
        yield return new WaitForSeconds (1f);
        ChangeHealth (-1);
        StartCoroutine (DecrementHealthEachSecond ());
    }
}
