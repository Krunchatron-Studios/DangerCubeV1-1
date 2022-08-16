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
	
	[Header("Player Scriptables")]
	public PlayerResources resources;
	public PlayerHealthAndShields healthAndShields;
	private void Start() {
		resources.experience = 0;
		resources.metal = 0;
		resources.bioGoo = 0;
		resources.silicate = 0;
		healthAndShields.playerHealthCurrent = healthAndShields.playerHealthMax;
		healthAndShields.playerShieldsCurrent = healthAndShields.playerShieldsMax;
	}
	private void Update() {
		mousePosition = Mouse.current.position.ReadValue();
		playerPosition = playerCube.transform.position;
	}
}
