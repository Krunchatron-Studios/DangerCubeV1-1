using System.Collections.Generic;
using ScriptableCode;
using UnityEngine;

public class UnlocksUI : MonoBehaviour {

	public static UnlocksUI uui;
	public UnlockData unlockData;
	public List<Upgrade> referenceList;
	public List<UnlockButton> unlockButtons;

	private void Start() {
		uui = this;
		if (unlockData.allUnlocks.Count <= 0) {
			PopulateUnlocks();
		}
		UpdateUnlocksPanel();
	}

	public void PopulateUnlocks() {
		for (int i = 0; i < referenceList.Count; i++) {
			Upgrade currentUpgrade = referenceList[i];
			if (currentUpgrade is Weapon) {
				unlockData.allUnlocks.Add(currentUpgrade.upgradeName, false);
			}
		}
	}

	public void UpdateUnlocksPanel() {
		for(int i = 0; i < referenceList.Count; i++) {
			referenceList[i].isUnlocked = unlockData.allUnlocks[referenceList[i].upgradeName];

			if (referenceList[i].isUnlocked) {
				unlockButtons[i].buttonImage.sprite = referenceList[i].upgradeSprite;
				unlockButtons[i].buttonText.text = referenceList[i].upgradeName;
			}
		}
	}
}
