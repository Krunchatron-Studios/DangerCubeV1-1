using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

    public CanvasGroup thisFadePanel;
    public void GoToEarth() {
        SceneManager.LoadScene("TestLevel");

    }
    public void ExitToTitle() {
        SceneManager.LoadScene("TitleScreen");
    }
}
