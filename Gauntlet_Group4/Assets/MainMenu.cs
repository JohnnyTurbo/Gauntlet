using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Toggle warriorToggle, wizardToggle, valkyrieToggle, elfToggle;
    public GameObject warriorGO, wizardGO, valkyrieGO, elfGO;

    GameObject gchud;

    void Awake() {
        gchud = GameController.instance.transform.FindChild ("HUD").gameObject;
        gchud.SetActive (false);
    }

    public void QuitGame() {
        Application.Quit ();
    }
    
    public void BeginGame() {
        if (!warriorToggle.isOn && !wizardToggle.isOn && !valkyrieToggle.isOn && !elfToggle.isOn) { return; }

        if (warriorToggle.isOn) {
            GameObject.Instantiate (warriorGO);
        }
        if (wizardToggle.isOn) {
            GameObject.Instantiate (wizardGO);
        }
        if (valkyrieToggle.isOn) {
            GameObject.Instantiate (valkyrieGO);
        }
        if (elfToggle.isOn) {
            GameObject.Instantiate (elfGO);
        }
        gchud.SetActive (true);
        Application.LoadLevel (Application.loadedLevel + 1);
    }
}
