using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

    public CanvasGroup thisFadePanel;
    public string sceneToLoad;
    public void GoToScene() {
        SceneManager.LoadScene(sceneToLoad);
    }
    public void StartFadeOut() {
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeOut() {
        while (thisFadePanel.alpha < 1) {
            thisFadePanel.alpha += 0.01f;
            yield return null;
        }
        thisFadePanel.interactable = false;
        yield return null;
        if (sceneToLoad != "Quit") {
            GoToScene();
        } else if (sceneToLoad == "Quit") {
            Application.Quit();
        }
    }
}
