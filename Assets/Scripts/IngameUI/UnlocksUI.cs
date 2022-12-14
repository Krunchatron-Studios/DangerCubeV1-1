using System.Collections.Generic;
using ScriptableCode;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnlocksUI : MonoBehaviour {

	public static UnlocksUI uui;
	public UnlockData unlockData;
	public List<Upgrade> referenceList;
	public List<UnlockButton> unlockButtons;

	public GameObject defaultSelection;

	private void Start() {
		uui = this;
		if (unlockData.allUnlocks.Count <= 0) {
			PopulateUnlocks();
		}
		UpdateUnlocksPanel();
	}

	private void PopulateUnlocks() {
		foreach (var currentUpgrade in referenceList) {
			if (currentUpgrade is Weapon) {
				unlockData.allUnlocks.Add(currentUpgrade.upgradeName, false);
			}
		}
	}

	public void UpdateUnlocksPanel() {
		EventSystem.current.SetSelectedGameObject(null);
		EventSystem.current.SetSelectedGameObject(defaultSelection);
		for(var i = 0; i < referenceList.Count; i++) {
			referenceList[i].isUnlocked = unlockData.allUnlocks[referenceList[i].upgradeName];

			if (referenceList[i].isUnlocked) {
				unlockButtons[i].buttonImage.sprite = referenceList[i].upgradeSprite;
				unlockButtons[i].buttonText.text = referenceList[i].upgradeName;
			}
		}
	}
}
