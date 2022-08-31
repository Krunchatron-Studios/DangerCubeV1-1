using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour {
    private bool _isPaused;
    public GameObject pausePanel;

    void Start() {
        _isPaused = false;
        pausePanel.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown("escape")) {
            Debug.Log("button registered");
            PauseGame();
        }
    }
    private void PauseGame() {
        _isPaused = !_isPaused;
        Debug.Log(_isPaused + " ,pause panel status.");
        if (_isPaused) {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        } else {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Resume() {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GiveUp() {
        SceneManager.LoadScene("LevelSelect");
    }

    public void ExitGame() {
        Application.Quit();
    }
}