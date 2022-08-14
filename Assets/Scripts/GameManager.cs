using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour {
	// reference to the game manager
	public static GameManager gm;
	public Vector2 mousePosition;
	// global references, same as doing GameObject.Instance.value
	// now we only need to access the ref as GameManager.gm.value for all refs
	public static PlayerMovement playerMove;
	public static MainCamera mainCam;
	
	// Area for player stats and info variables
	// hp, shields, moveSpeed, attack power, rate of fire, loadout[]

	private void Update() {
		mousePosition = Mouse.current.position.ReadValue();
	}
}
