using UnityEngine;
using System.Collections;

public class Warrior : Player {

    void Awake() {
        DontDestroyOnLoad (transform.gameObject);
        horizontalInput = "Controller1Horizontal";
        verticalInput = "Controller1Vertical";
        attackInput = "Controller1Attack";
        itemInput = "Controller1Item";
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
}
