using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController instance;

    public List<Player> playersInGame;

    public GameObject warriorGO, wizardGO, valkyrieGO, elfGO, warriorJoinText, wizardJoinText, valkyrieJoinText, elfJoinText;

    int warriorHealth, warriorScore, warriorKeys, warriorPotions, wizardHealth, wizardScore, wizardKeys, wizardPotions, valkyrieHealth, valkyrieScore, valkyrieKeys, valkyriePotions, elfHealth, elfScore, elfKeys, elfPotions;

    public Text warriorHealthtext, warriorScoretext, warriorKeystext, warriorPotionstext, wizardHealthtext, wizardScoretext, wizardKeystext, wizardPotionstext, valkyrieHealthtext, valkyrieScoretext, valkyrieKeystext, valkyriePotionstext, elfHealthtext, elfScoretext, elfKeystext, elfPotionstext, levelNumberText;
    public bool warriorSpawned = false, wizardSpawned = false, valkyrieSpawned = false, elfSpawned = false;
    bool gameStart;
    int levelNumber = 0;
    Canvas HUDCanvas;

    void Awake() {
        DontDestroyOnLoad (transform.gameObject);
        playersInGame = new List<Player> ();
        instance = this;
        HUDCanvas = transform.FindChild ("HUD").GetComponent<Canvas>();

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
        gameStart = true;
        levelNumber++;
        levelNumberText.text = "Level: " + levelNumber;
        HUDCanvas.worldCamera = Camera.main;
        for (int index = 0; index < playersInGame.Count; index++) {
            playersInGame[index].transform.position = PlayerSpawner.instance.spawnSpots[index] + PlayerSpawner.instance.transform.position;
        }
    }

    void Update() {
        if (gameStart) {
            if ((Input.GetKeyDown (KeyCode.Alpha1) || Input.GetButtonDown ("Controller1Attack")) && !warriorSpawned) {
                SpawnGO (warriorGO);
            }
            if ((Input.GetKeyDown (KeyCode.Alpha2) || Input.GetButtonDown ("Controller2Attack")) && !wizardSpawned) {
                SpawnGO (wizardGO);
            }
            if ((Input.GetKeyDown (KeyCode.Alpha3) || Input.GetButtonDown ("Controller3Attack")) && !valkyrieSpawned) {
                SpawnGO (valkyrieGO);
            }
            if ((Input.GetKeyDown (KeyCode.Alpha4) || Input.GetButtonDown ("Controller4Attack")) && !elfSpawned) {
                SpawnGO (elfGO);
            }

            if (playersInGame.Count <= 0) {
                gameStart = false;
                Application.LoadLevel (6);
            }
        }

    }

    void SpawnGO(GameObject newPlayer) {
        Instantiate (newPlayer, PlayerSpawner.instance.spawnSpots[playersInGame.Count] + PlayerSpawner.instance.transform.position, Quaternion.identity);
    }

}
