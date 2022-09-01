using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

public class Fade : MonoBehaviour
{
    // private void Awake() {
    //     FadeInFunc();
    // }

    public void FadeInFunc() {
        StartCoroutine(FadeIn());
    }

    public void FadeOutFunc() {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn() {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0) {
            canvasGroup.alpha -= canvasGroup.alpha - Time.deltaTime / 2;
            yield return null;
        }
        // canvasGroup.interactable = false;
        // yield return null;
    }
    
    IEnumerator FadeOut() {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha < 1) {
            canvasGroup.alpha += canvasGroup.alpha - Time.deltaTime / 2;
            yield return null;
        }
        // canvasGroup.interactable = false;
        // yield return null;
    }
    
}
