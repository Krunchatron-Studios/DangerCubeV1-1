using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager gm;
	public GameObject playerCube;
	public static PlayerMovement playerMove;
	public static MainCamera mainCam;
	public LevelUpPanel lvlPanel;
	
	[Header("Scriptable Object")]
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

}
