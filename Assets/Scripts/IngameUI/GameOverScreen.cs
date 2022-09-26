using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
	public AudioSource audioSource;

	private void Start() {
		audioSource.Play();
	}

	public void RestartGame() {
		audioSource.Stop();
		SoundManager.sm.buttonPress.Play();
		SceneManager.LoadScene("TestLevel");
	}

	public void ExitGame() {
		audioSource.Stop();
		SoundManager.sm.buttonPress.Play();
		SceneManager.LoadScene("TitleScreen");
	}
}
