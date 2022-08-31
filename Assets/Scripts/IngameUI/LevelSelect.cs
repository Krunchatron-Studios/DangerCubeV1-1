
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelSelect : MonoBehaviour
{
    public void GoToEarth() {
        SceneManager.LoadScene("TestLevel");
    }
}
