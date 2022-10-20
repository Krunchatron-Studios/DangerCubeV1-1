using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelUpPanel : MonoBehaviour {

	public GameObject defaultMenuSelection;
	public UpgradeButton[] upgradeButtons;

	private void Awake() {
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(defaultMenuSelection);
	}
}
