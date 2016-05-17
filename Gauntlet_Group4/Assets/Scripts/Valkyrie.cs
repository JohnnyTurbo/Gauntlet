using UnityEngine;
using System.Collections;

public class Valkyrie : Player {

    void Awake() {
        DontDestroyOnLoad (transform.gameObject);
        horizontalInput = "Controller3Horizontal";
        verticalInput = "Controller3Vertical";
        attackInput = "Controller3Attack";
        itemInput = "Controller3Item";
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
}
