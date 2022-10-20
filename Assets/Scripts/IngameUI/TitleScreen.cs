using Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	public UnlocksUI unlocksUI;
	public GameObject selectionAfterClosing;

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

		unlocksUI.gameObject.SetActive(!unlocksUI.gameObject.activeInHierarchy);
		TitleSoundManager.tsm.buttonPress.Play();
		UnlocksUI.uui.UpdateUnlocksPanel();
		if (!unlocksUI.gameObject.activeInHierarchy) {
			EventSystem.current.SetSelectedGameObject(null);
			EventSystem.current.SetSelectedGameObject(selectionAfterClosing);
		}
	}
}
