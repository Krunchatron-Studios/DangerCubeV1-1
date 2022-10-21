using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class GameOverScreen : MonoBehaviour {

	public GameObject defaultSelection;
	
	private void Start() {
		TitleSoundManager.tsm.titleMusic.Play();
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(defaultSelection);
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
