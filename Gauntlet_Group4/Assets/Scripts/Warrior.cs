using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Warrior : Player {

    public static Warrior instance;

    void Awake() {
        DontDestroyOnLoad (transform.gameObject);
        instance = this;
        GameController.instance.warriorJoinText.SetActive (false);
        GameController.instance.warriorSpawned = true;
        horizontalInput = "Controller1Horizontal";
        verticalInput = "Controller1Vertical";
        attackInput = "Controller1Attack";
        itemInput = "Controller1Item";
        ChangeHealth (1000);
        StartCoroutine (DecrementHealthEachSecond ());
    }

    protected override void Attack ()
	{
		base.Attack ();
	}

    public override void IncreaseScore(int newScore) {
        base.IncreaseScore (newScore);
        GameController.instance.warriorScoretext.text = "Score: " + score;
    }

    public override void ChangeHealth(int numHealth) {
        base.ChangeHealth (numHealth);
        GameController.instance.warriorHealthtext.text = "Health: " + health;
    }

    public override void ChangeNumKeys(int numKeys) {
        base.ChangeNumKeys (numKeys);
        GameController.instance.warriorKeystext.text = "Keys: " + keys;
    }

    public override void ChangePotions(int numPotions) {
        base.ChangePotions (numPotions);
        GameController.instance.warriorPotionstext.text = "Potions: " + potions;
    }

    void OnDestroy() {
        GameController.instance.playersInGame.Remove (this);
        GameController.instance.warriorJoinText.SetActive (true);
        GameController.instance.warriorJoinText.transform.FindChild ("Panel").FindChild ("Text").GetComponent<Text> ().text = "Defeated!";
    }

    IEnumerator DecrementHealthEachSecond() {
        yield return new WaitForSeconds (1f);
        ChangeHealth (-1);
        StartCoroutine (DecrementHealthEachSecond ());
    }
}
