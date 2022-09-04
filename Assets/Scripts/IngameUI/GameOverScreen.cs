using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
	public AudioSource audioSource;

	private void Start() {
		audioSource.Play();
	}

	public void RestartGame() {
		audioSource.Play();
		SceneManager.LoadScene("TestLevel");
	}

	public void LoadLevel(string lvlToLoad) {
		audioSource.Stop();
		SceneManager.LoadScene(lvlToLoad);
	}

	public void ExitGame() {
		audioSource.Stop();
		SceneManager.LoadScene("TitleScreen");
	}
}
