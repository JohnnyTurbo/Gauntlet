using UnityEngine;
using System.Collections;

public class Wizard : Player {

    void Awake() {
        DontDestroyOnLoad (transform.gameObject);
        horizontalInput = "Controller2Horizontal";
        verticalInput = "Controller2Vertical";
        attackInput = "Controller2Attack";
        itemInput = "Controller2Item";
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
}
