using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpPanel : MonoBehaviour {

	public UpgradeButton[] upgradeButtons;
	
	public Image[] upgradeImages;
	public TextMeshProUGUI[] upgradeNames;
	public TextMeshProUGUI upgradeDescription;
	public Weapon[] referenceWeaponsArray;

	public void UpdateLevelUpPanel() {
		Debug.Log("level up");
		
		for (int i = 0; i < upgradeButtons.Length; i++) {

			for (int j = 0; j < referenceWeaponsArray.Length; j++) {
				if (upgradeButtons[j].upgradeName == referenceWeaponsArray[j].weaponName) {
					upgradeImages[i].sprite = referenceWeaponsArray[j].weaponSprite;
					upgradeNames[i].text = referenceWeaponsArray[j].weaponName;
					upgradeDescription.text = referenceWeaponsArray[j].weaponDescription;
				}
			}
		}
	}
}
