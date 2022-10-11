using System.Collections;
using UnityEngine;

public class TimedDeactivate : MonoBehaviour {

	public float timeTilDeactivation = 0.5f;
	public GameObject thisParent;
	private void FixedUpdate() {
		ShutOffTimer();
	}

	IEnumerator DelayedDeactivate() {
		yield return new WaitForSeconds(timeTilDeactivation);
		gameObject.SetActive(false);
		Debug.Log($"did it work?: {gameObject.activeInHierarchy}");
	}

	private void ShutOffTimer() {
		if (gameObject.activeInHierarchy) {
			Debug.Log($"start time: {gameObject.activeInHierarchy}");
			StartCoroutine(DelayedDeactivate());
		}
	}
}
