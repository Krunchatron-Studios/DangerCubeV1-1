using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	public AudioSource audioSource;
	public void StartGame() {
		audioSource.Play();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void ExitGame() {
		Application.Quit();
	}
}
