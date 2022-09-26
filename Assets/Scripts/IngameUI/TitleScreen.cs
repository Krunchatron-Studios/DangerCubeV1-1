using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	private void Start() {
		TitleSoundManager.tsm.titleMusic.Play();
	}

	public void StartGame() {
		TitleSoundManager.tsm.titleMusic.Stop();
		TitleSoundManager.tsm.buttonPress.Play();
		SceneManager.LoadScene("TestLevel");
	}

	public void LoadLevel(string lvlToLoad) {
		TitleSoundManager.tsm.titleMusic.Stop();
		TitleSoundManager.tsm.buttonPress.Play();
		SceneManager.LoadScene(lvlToLoad);
	}

	public void ExitToDesktop() {
		TitleSoundManager.tsm.titleMusic.Stop();
		TitleSoundManager.tsm.buttonPress.Play();
		Application.Quit();
	}
}
