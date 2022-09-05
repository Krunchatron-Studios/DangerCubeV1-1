using System.Collections;
using UnityEngine;

public class Fade : MonoBehaviour {
    public CanvasGroup thisFadePanel;
    private void Awake() {
        FadeInFunc();
    }

    public void FadeInFunc() {
        StartCoroutine(FadeIn());
    }

    public void FadeOutFunc() {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn() {
        while (thisFadePanel.alpha > 0) {
            thisFadePanel.alpha -= 0.01f;
            yield return null;
        }
        thisFadePanel.interactable = false;
        yield return null;
    }
    
    IEnumerator FadeOut() {
        while (thisFadePanel.alpha < 1) {
            thisFadePanel.alpha += 0.01f;
            yield return null;
        }
        thisFadePanel.interactable = false;
        yield return null;
    }
}
