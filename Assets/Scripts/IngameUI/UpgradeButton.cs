using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour {
	public LevelUpPanel lvlPanel;
	public string upgradeName;
	public Image upgradeSprite;
	public string upgradeDescription = "this is a test string description";
	public TextMeshProUGUI upgradeNameText;

	private void Start() {
		GenerateUpgrade();
	}
	
	public void GenerateUpgrade() {
		var randomUpgradeIndex= Random.Range(0, lvlPanel.referenceWeaponsArray.Length);
		upgradeName = lvlPanel.referenceWeaponsArray[randomUpgradeIndex].weaponName;
		UpdateLevelUpPanel();
	}
	public void UpdateLevelUpPanel() {
		
		for (int j = 0; j < lvlPanel.referenceWeaponsArray.Length; j++) {
			if (upgradeName == lvlPanel.referenceWeaponsArray[j].weaponName) {
				upgradeSprite.sprite = lvlPanel.referenceWeaponsArray[j].weaponSprite; 
				upgradeName = lvlPanel.referenceWeaponsArray[j].weaponName;
				upgradeNameText.text = upgradeName;
				upgradeDescription = lvlPanel.referenceWeaponsArray[j].weaponDescription;
			}
		}
	}

	public void SelectUpgrade() {
		SoundManager.sm.buttonPress.Play();
		WeaponSystem.Instance.ActivateWeaponSystem(upgradeName);
		lvlPanel.gameObject.SetActive(false);
		Time.timeScale = 1f;
	}
}
