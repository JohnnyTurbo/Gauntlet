using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Elf : Player {

    public static Elf instance;

    void Awake() {
        DontDestroyOnLoad (transform.gameObject);
        instance = this;
        GameController.instance.elfJoinText.SetActive (false);
        GameController.instance.elfSpawned = true;
        horizontalInput = "Controller4Horizontal";
        verticalInput = "Controller4Vertical";
        attackInput = "Controller4Attack";
        itemInput = "Controller4Item";
        ChangeHealth (1000);
        StartCoroutine (DecrementHealthEachSecond ());
    }

    public override void IncreaseScore(int newScore) {
        base.IncreaseScore (newScore);
        GameController.instance.elfScoretext.text = "Score: " + score;
    }

    public override void ChangeHealth(int numHealth) {
        base.ChangeHealth (numHealth);
        GameController.instance.elfHealthtext.text = "Health: " + health;
    }

    public override void ChangeNumKeys(int numKeys) {
        base.ChangeNumKeys (numKeys);
        GameController.instance.elfKeystext.text = "Keys: " + keys;
    }

    public override void ChangePotions(int numPotions) {
        base.ChangePotions (numPotions);
        GameController.instance.elfPotionstext.text = "Potions: " + potions;
    }

    void OnDestroy() {
        GameController.instance.playersInGame.Remove (this);
        GameController.instance.elfJoinText.SetActive (true);
        GameController.instance.elfJoinText.transform.FindChild ("Panel").FindChild ("Text").GetComponent<Text> ().text = "Defeated!";
    }

    IEnumerator DecrementHealthEachSecond() {
        yield return new WaitForSeconds (1f);
        ChangeHealth (-1);
        StartCoroutine (DecrementHealthEachSecond ());
    }
}
