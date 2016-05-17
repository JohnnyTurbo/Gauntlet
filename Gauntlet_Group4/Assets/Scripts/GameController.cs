using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController instance;

	public List<Player> playersInGame;

    int warriorHealth, warriorScore, warriorKeys, warriorPotions, wizardHealth, wizardScore, wizardKeys, wizardPotions, valkyrieHealth, valkyrieScore, valkyrieKeys, valkyriePotions, elfHealth, elfScore, elfKeys, elfPotions;

    public Text warriorHealthtext, warriorScoretext, warriorKeystext, warriorPotionstext, wizardHealthtext, wizardScoretext, wizardKeystext, wizardPotionstext, valkyrieHealthtext, valkyrieScoretext, valkyrieKeystext, valkyriePotionstext, elfHealthtext, elfScoretext, elfKeystext, elfPotionstext;

    void Awake(){
        DontDestroyOnLoad (transform.gameObject);
        playersInGame = new List<Player> ();
		instance = this;

        warriorHealthtext.text = "Health: 0";
        wizardHealthtext.text = "Health: 0";
        valkyrieHealthtext.text = "Health: 0";
        elfHealthtext.text = "Health: 0";

        warriorScoretext.text = "Score: 0";
        wizardScoretext.text = "Score: 0";
        valkyrieScoretext.text = "Score: 0";
        elfScoretext.text = "Score: 0";

        warriorKeystext.text = "Keys: 0";
        wizardKeystext.text = "Keys: 0";
        valkyrieKeystext.text = "Keys: 0";
        elfKeystext.text = "Keys: 0";

        warriorPotionstext.text = "Potions: 0";
        wizardPotionstext.text = "Potions: 0";
        valkyriePotionstext.text = "Potions: 0";
        elfPotionstext.text = "Potions: 0";
    }

    public void BeginLevel() {
        for (int index = 0; index < playersInGame.Count; index++) {
            playersInGame[index].transform.position = PlayerSpawner.instance.spawnSpots[index] + PlayerSpawner.instance.transform.position;
        }
    }

}
