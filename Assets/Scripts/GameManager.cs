using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour {
	// reference to the game manager
	public static GameManager gm;
	public Vector2 mousePosition; // not in use yet
	public Vector2 playerPosition;

	public GameObject playerCube;
	public static PlayerMovement playerMove;
	public static MainCamera mainCam;
	
	// Area for player stats and info variables
	// hp, shields, moveSpeed, attack power, rate of fire, loadout[]

	private void Update() {
		mousePosition = Mouse.current.position.ReadValue();
		playerPosition = playerCube.transform.position;
	}
}
