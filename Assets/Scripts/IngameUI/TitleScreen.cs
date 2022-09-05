using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	public AudioSource audioSource;
	public void StartGame() {
		audioSource.Play();
		SceneManager.LoadScene("TestLevel");
	}

	public void LoadLevel(string lvlToLoad) {
		audioSource.Stop();
		SceneManager.LoadScene(lvlToLoad);
	}

	public void ExitToDesktop() {
		Application.Quit();
	}
}
