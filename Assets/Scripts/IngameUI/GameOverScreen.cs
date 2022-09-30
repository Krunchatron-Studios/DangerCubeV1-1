using System;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour {
	private void Start() {
		TitleSoundManager.tsm.titleMusic.Play();
	}

	public void RestartGame() {
		SceneManager.LoadScene("TestLevel");
		TitleSoundManager.tsm.titleMusic.Stop();
		TitleSoundManager.tsm.buttonPress.Play();
	}

	public void ExitGame() {
		SceneManager.LoadScene("TitleScreen");
		TitleSoundManager.tsm.titleMusic.Stop();
		TitleSoundManager.tsm.buttonPress.Play();
	}
}
