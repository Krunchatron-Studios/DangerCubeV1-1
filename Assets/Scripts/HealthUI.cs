using UnityEngine;
using MoreMountains.Feedbacks;

public class HealthUI : MonoBehaviour {
	public GameObject[] healthChunksArray;
	public GameObject healthChunk;
	public PlayerHealthAndShields playerHealthData;
	public MMF_Player shakeFeedback;
	public bool canBeHurt;
	public float invulTimer = 1.5f;
	private float _resetTimer;


	private void Start() {
		AddHealthChunks();
	}

	private void Update() {
		SetInvulTimer();
	}

	public void AddHealthChunks() {
		
		for (int i = 0; i < playerHealthData.playerHealthMax; i++) {
			
			if (i <= playerHealthData.playerHealthCurrent) {
				healthChunksArray[i].SetActive(true);
				Debug.Log("health bars");
			}
		}
	}

	public void RemoveHealthChunk() {
		playerHealthData.playerHealthCurrent--;
		if (playerHealthData.playerHealthCurrent <= 0) {
			// Game over logic
		}
		int chunkIndex = Mathf.FloorToInt(playerHealthData.playerHealthCurrent);
		if (chunkIndex < 0) {
			chunkIndex = 0;
		}
		healthChunksArray[chunkIndex].SetActive(false);
		canBeHurt = false;
	}

	private void SetInvulTimer() {
		if (!canBeHurt) {
			_resetTimer = Time.time + invulTimer;
		}

		if (Time.time > _resetTimer) {
			canBeHurt = true;
		}
	}
}
