using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.InputSystem;
public class PausePanel : MonoBehaviour {
    private bool _isPaused;
    public GameObject pausePanel;
    public MMTimeManager timeManager;

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
        SoundManager.sm.pauseMenu.Play();
        if (!_isPaused) {
            pausePanel.SetActive(true);
            timeManager.SetTimescaleTo(0f);
            _isPaused = true;
        } else {
            pausePanel.SetActive(false);
            timeManager.SetTimescaleTo(1f);
            _isPaused = false;
        }
    }
    public void Resume() {
        if (_isPaused) {
            pausePanel.SetActive(false);
            timeManager.SetTimescaleTo(1f);
            SoundManager.sm.buttonPress.Play();
            _isPaused = false;
        }
    }

    public void ExitGame() {
        Application.Quit();
    }
}
