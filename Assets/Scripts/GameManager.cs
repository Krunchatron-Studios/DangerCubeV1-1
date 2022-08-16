using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour {
	public static GameManager gm;
	public static Projectile projectile;
	public Vector2 mousePosition; 
	public Vector2 playerPosition;

	public GameObject playerCube;
	public static PlayerMovement playerMove;
	public static MainCamera mainCam;
	
	[Header("Player Scriptables")]
	public PlayerResources resources;
	public PlayerHealthAndShields healthAndShields;

	private void Update() {
		mousePosition = Mouse.current.position.ReadValue();
		playerPosition = playerCube.transform.position;
	}
}
