using TMPro;
using UnityEngine;

public class LevelUpPanel : MonoBehaviour {

	public UpgradeButton[] upgradeButtons;
	public TextMeshProUGUI upgradeDescription;
	public Weapon[] referenceWeaponsArray;

	public void RefreshChoices() {
		for (int i = 0; i < upgradeButtons.Length; i++) {
			upgradeButtons[i].GenerateUpgrade();
		}
	}
	
	
}
