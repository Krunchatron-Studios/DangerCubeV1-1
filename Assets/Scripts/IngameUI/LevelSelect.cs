using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour {
    public void GoToEarth() {
        SceneManager.LoadScene("TestLevel");
    }
}
