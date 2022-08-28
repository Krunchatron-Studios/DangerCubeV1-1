using UnityEngine;
using MoreMountains.Feedbacks;

public class HealthUI : MonoBehaviour {
	public GameObject[] healthChunksArray;
	public GameObject healthChunk;
	public PlayerHealthAndShields playerHealthData;
	public MMF_Player shakeFeedback;
	
	private void Start() {
		UpdateHealthChunks();
	}

	public void UpdateHealthChunks() {
		playerHealthData.playerHealthCurrent--;
		
		for (int i = 0; i < playerHealthData.playerHealthMax; i++) {
			healthChunksArray[i].SetActive(false);
			if (i <= playerHealthData.playerHealthCurrent) {
				healthChunksArray[i].SetActive(true);
				Debug.Log("health bars");
			}
		}
	}

	public void ExplodeHealthChunk() {
		
	}
}
