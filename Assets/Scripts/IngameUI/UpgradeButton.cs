using System.Collections.Generic;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour {
	public LevelUpPanel lvlPanel;
	public MMTimeManager timeManager; 
	public string weaponOrTechName;
	public Image upgradeSprite;
	public Image thisImage;
	public string upgradeDescription = "this is a test string description";
	public TextMeshProUGUI upgradeNameText;
	public TextMeshProUGUI upgradeDescText;
	private Upgrade _upgrade;

	
	private void Start() {
		thisImage = GetComponent<Image>();
		upgradeSprite = GetComponent<Image>();
	}
	
	public void GenerateMinorBioUpgrade() {
		int randomIndex = Random.Range(0, UpgradesList.ul.bioUpgradesMinor.Count);
		Upgrade upgrade = UpgradesList.ul.bioUpgradesMinor[randomIndex];
		weaponOrTechName = upgrade.upgradeName;
		_upgrade = upgrade;
		UpdateLevelUpPanel();
	}
	public void GenerateMinorMetalUpgrade() {
		int randomIndex = Random.Range(0, UpgradesList.ul.bioUpgradesMinor.Count);
		Upgrade upgrade = UpgradesList.ul.metalUpgradesMinor[randomIndex];
		weaponOrTechName = upgrade.upgradeName;
		_upgrade = upgrade;
		UpdateLevelUpPanel();
	}
	public void GenerateMinorSilicateUpgrade() {
		int randomIndex = Random.Range(0, UpgradesList.ul.bioUpgradesMinor.Count);
		Upgrade upgrade = UpgradesList.ul.silicateUpgradesMinor[randomIndex];
		weaponOrTechName = upgrade.upgradeName;
		_upgrade = upgrade;
		UpdateLevelUpPanel();
	}

	public void GenerateMajorUpgrade() {
		string[] temp = { "Bio", "Metal", "Silicate" };
		int index = Random.Range(0, 3);
		Upgrade upgrade = null;
		Debug.Log($"Major Index: {index}");
		if (index == 0) {
			upgrade = UpgradesList.ul.bioUpgradesMajor[Random.Range(0, UpgradesList.ul.bioUpgradesMajor.Count)];
			Debug.Log($"Major Index1: {upgrade}");
		} else if (index == 1) {
			upgrade = UpgradesList.ul.metalUpgradesMajor[Random.Range(0, UpgradesList.ul.metalUpgradesMajor.Count)];
			Debug.Log($"Major Index2: {upgrade}");
		} else if (index == 2) {
			upgrade = UpgradesList.ul.silicateUpgradesMajor[Random.Range(0, UpgradesList.ul.silicateUpgradesMajor.Count)];
			Debug.Log($"Major Index3: {upgrade}");
		}
		if (upgrade) {
			weaponOrTechName = upgrade.upgradeName;
			Debug.Log($"upgrade? {upgrade}");
		}
		_upgrade = upgrade;
		
		UpdateLevelUpPanel();
	}
	
	public void UpdateLevelUpPanel() {
		List<Upgrade> refArray = UpgradesList.ul.upgradeList;

		for (int i = 0; i < refArray.Count; i++) {
			Debug.Log(refArray[i].upgradeName + "test");
			if (_upgrade.upgradeName == refArray[i].upgradeName) {
				upgradeSprite.sprite = refArray[i].upgradeSprite; 
				weaponOrTechName = refArray[i].upgradeName;
				upgradeNameText.text = weaponOrTechName;
				upgradeDescription = refArray[i].description;
				upgradeDescText.text = upgradeDescription;
			}
		}
	}

	public void SelectUpgrade() {
		SoundManager.sm.buttonPress.Play();
		lvlPanel.gameObject.SetActive(false);
		timeManager.SetTimescaleTo(1f);
		ActivateAndRemove(_upgrade.upgradeType, _upgrade.upgradeTier, _upgrade.upgradeName);
	}

	public void ActivateAndRemove(string type, string tier, string abilityName) {
		UpgradesList list = UpgradesList.ul;
		Upgrade currentUpgrade;

		if (type == "Bio") {
			if (tier == "Minor") {
				for (int i = 0; i < list.bioUpgradesMinor.Count; i++) {
					currentUpgrade = list.bioUpgradesMinor[i];
					if (list.bioUpgradesMinor[i].upgradeName == abilityName) {
						list.bioUpgradesMinor[i].gameObject.SetActive(true);
						list.bioUpgradesMinor.Remove(currentUpgrade);
					}
				}
			}

			if (tier == "Major") {
				for (int i = 0; i < list.bioUpgradesMajor.Count; i++) {
					currentUpgrade = list.bioUpgradesMajor[i];
					if (list.bioUpgradesMajor[i].upgradeName == abilityName) {
						list.bioUpgradesMajor[i].gameObject.SetActive(true);
						list.bioUpgradesMajor.Remove(currentUpgrade);
					}
				}
			}
		}

		if (type == "Metal") {
			if (tier == "Minor") {
				for (int i = 0; i < list.metalUpgradesMinor.Count; i++) {
					currentUpgrade = list.metalUpgradesMinor[i];
					if (list.metalUpgradesMinor[i].upgradeName == abilityName) {
						list.metalUpgradesMinor[i].gameObject.SetActive(true);
						list.metalUpgradesMinor.Remove(currentUpgrade);
					}
				}
			}

			if (tier == "Major") {
				for (int i = 0; i < list.metalUpgradesMajor.Count; i++) {
					currentUpgrade = list.metalUpgradesMajor[i];
					if (list.metalUpgradesMajor[i].upgradeName == abilityName) {
						list.metalUpgradesMajor[i].gameObject.SetActive(true);
						list.metalUpgradesMajor.Remove(currentUpgrade);
					}
				}
			}
		}

		if (type == "Silicate") {
			if (tier == "Minor") {
				for (int i = 0; i < list.silicateUpgradesMinor.Count; i++) {
					currentUpgrade = list.silicateUpgradesMinor[i];
					if (list.silicateUpgradesMinor[i].upgradeName == abilityName) {
						list.silicateUpgradesMinor[i].gameObject.SetActive(true);
						list.silicateUpgradesMinor.Remove(currentUpgrade);
					}
				}
			}

			if (tier == "Major") {
				for (int i = 0; i < list.silicateUpgradesMajor.Count; i++) {
					currentUpgrade = list.silicateUpgradesMajor[i];
					if (list.silicateUpgradesMajor[i].upgradeName == abilityName) {
						list.silicateUpgradesMajor[i].gameObject.SetActive(true);
						list.silicateUpgradesMajor.Remove(currentUpgrade);
					}
				}
			}
		}
		
	}
}
