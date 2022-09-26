using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	public AudioSource audioSource;

	private void Start() {
		audioSource.Play();
	}

	public void StartGame() {
		audioSource.Stop();
		SoundManager.sm.buttonPress.Play();
		SceneManager.LoadScene("TestLevel");
	}

	public void LoadLevel(string lvlToLoad) {
		audioSource.Stop();
		SoundManager.sm.buttonPress.Play();
		SceneManager.LoadScene(lvlToLoad);
	}

	public void ExitToDesktop() {
		audioSource.Stop();
		SoundManager.sm.buttonPress.Play();
		Application.Quit();
	}
}
