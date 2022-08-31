
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSelect : MonoBehaviour {

    public GameObject fadeIn;
    public GameObject fadeOut;

    void Start() {
        fadeIn.SetActive(true);
        StartCoroutine(Toggle(fadeOut));
    }

    public void GoToEarth() {
        fadeIn.SetActive(true);
        StartCoroutine(Toggle(fadeIn));
        SceneManager.LoadScene("TestLevel");
    }

    private IEnumerator Toggle(GameObject fade) {
        yield return new WaitForSeconds(1);
        fade.SetActive(false);
    }
}
