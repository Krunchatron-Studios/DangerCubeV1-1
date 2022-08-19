using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour {
	public static GameManager gm;
	public GameObject playerCube;
	public static PlayerMovement playerMove;
	public static MainCamera mainCam;
	public LevelUpPanel lvlPanel;
	
	[Header("Player Scriptables")]
	public PlayerResources resources;
	public PlayerHealthAndShields healthAndShields;
	public int bioGoo;
	
	private void Start() {
		resources.experience = 0;
		resources.metal = 0;
		resources.bioGoo = 0;
		resources.silicate = 0;
		healthAndShields.playerHealthCurrent = healthAndShields.playerHealthMax;
		healthAndShields.playerShieldsCurrent = healthAndShields.playerShieldsMax;
	}

	private void LookAtMouse() {
		Vector3 mousePosition = Mouse.current.position.ReadValue();
		Vector2 fireDirection = mousePosition - transform.position;
		float angle = Vector2.SignedAngle(Vector2.right, fireDirection);
		transform.eulerAngles = new Vector3(0, 0, angle);
	}
}
