using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	public UnlocksUI unlocksUI;

	public void StartGame() {
		SceneManager.LoadScene("TestLevel");
		TitleSoundManager.tsm.buttonPress.Play();
		TitleSoundManager.tsm.titleMusic.Stop();
	}

	public void LoadLevel(string lvlToLoad) {
		SceneManager.LoadScene(lvlToLoad);
		TitleSoundManager.tsm.buttonPress.Play();
		TitleSoundManager.tsm.titleMusic.Stop();
	}

	public void ExitToDesktop() {
		Application.Quit();
		TitleSoundManager.tsm.buttonPress.Play();
		TitleSoundManager.tsm.titleMusic.Stop();
	}

	public void OpenUnlockScreen() {
		UnlocksUI.uui.UpdateUnlocksPanel();
		unlocksUI.gameObject.SetActive(!unlocksUI.gameObject.activeInHierarchy);
		TitleSoundManager.tsm.buttonPress.Play();
	}
}
