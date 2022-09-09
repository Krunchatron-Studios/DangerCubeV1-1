using UnityEngine;
using UnityEngine.InputSystem;
public class PausePanel : MonoBehaviour {
    private bool _isPaused;
    public GameObject pausePanel;

    void Start() {
        _isPaused = false;
        pausePanel.SetActive(false);
    }
    void Update() {
        if (Keyboard.current.escapeKey.wasPressedThisFrame) {
            PauseGame();
        }
    }
    private void PauseGame() {
        _isPaused = !_isPaused;
        SoundManager.sm.pauseMenu.Play();
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
        SoundManager.sm.buttonPress.Play();
    }

    public void ExitGame() {
        Application.Quit();
    }
}
