using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

    void Start() {
        GameController.instance.warriorJoinText.SetActive (false);
        GameController.instance.wizardJoinText.SetActive (false);
        GameController.instance.valkyrieJoinText.SetActive (false);
        GameController.instance.elfJoinText.SetActive (false);
    }

    public void QuitGame() {
        Application.Quit ();
    }
}
