using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {

	private void Start() {
		TitleSoundManager.tsm.titleMusic.Play();
	}

	public void RestartGame() {
		TitleSoundManager.tsm.titleMusic.Stop();
		TitleSoundManager.tsm.buttonPress.Play();
		SceneManager.LoadScene("TestLevel");
	}

	public void ExitGame() {
		TitleSoundManager.tsm.titleMusic.Stop();
		TitleSoundManager.tsm.buttonPress.Play();
		SceneManager.LoadScene("TitleScreen");
	}
}
