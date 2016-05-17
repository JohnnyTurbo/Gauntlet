using UnityEngine;
using System.Collections;

public class Elf : Player {

    void Awake() {
        DontDestroyOnLoad (transform.gameObject);
        horizontalInput = "Controller4Horizontal";
        verticalInput = "Controller4Vertical";
        attackInput = "Controller4Attack";
        itemInput = "Controller4Item";
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
}
