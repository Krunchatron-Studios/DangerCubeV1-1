using UnityEngine;

public class MainCamera : MonoBehaviour {
	
	public static MainCamera Instance;
	
	public Rigidbody2D playerRb2D;

	private void Start() {
		Instance = this;
	}
	private void Update() {
		FollowPlayer();
	}
	// Script to make the camera follow the player (IDmgAndHpInterface = true)
	public void FollowPlayer() {

		if (playerRb2D) {
			transform.position = new Vector3(playerRb2D.position.x, playerRb2D.position.y, -10);
		}
	}
}
