using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour {
	public LevelUpPanel lvlPanel;
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
		Debug.Log("test1");
		int randomIndex = Random.Range(0, UpgradesList.ul.bioUpgradesMinor.Length);
		Upgrade upgrade = UpgradesList.ul.bioUpgradesMinor[randomIndex];
		weaponOrTechName = upgrade.upgradeName;
		UpdateLevelUpPanel();
	}
	public void GenerateMinorMetalUpgrade() {
		Debug.Log("test2");
		int randomIndex = Random.Range(0, UpgradesList.ul.bioUpgradesMinor.Length);
		Upgrade upgrade = UpgradesList.ul.metalUpgradesMinor[randomIndex];
		weaponOrTechName = upgrade.upgradeName;
		UpdateLevelUpPanel();
	}
	public void GenerateMinorSilicateUpgrade() {
		Debug.Log("test3");
		int randomIndex = Random.Range(0, UpgradesList.ul.bioUpgradesMinor.Length);
		Upgrade upgrade = UpgradesList.ul.silicateUpgradesMinor[randomIndex];
		weaponOrTechName = upgrade.upgradeName;
		UpdateLevelUpPanel();
	}

	public void GenerateMajorUpgrade() {
		string[] temp = { "Bio", "Metal", "Silicate" };
		int index = Random.Range(0, temp.Length);
		Upgrade upgrade = null;
		
		if (index == 0) {
			upgrade = UpgradesList.ul.bioUpgradesMajor[Random.Range(0, UpgradesList.ul.bioUpgradesMajor.Length)];
		} else if (index == 1) {
			upgrade = UpgradesList.ul.metalUpgradesMajor[Random.Range(0, UpgradesList.ul.metalUpgradesMajor.Length)];
		} else if (index == 2) {
			upgrade = UpgradesList.ul.silicateUpgradesMajor[Random.Range(0, UpgradesList.ul.silicateUpgradesMajor.Length)];
		}
		if (upgrade) {
			weaponOrTechName = upgrade.upgradeName;
		}
		UpdateLevelUpPanel();
	}
	
	public void UpdateLevelUpPanel() {
		List<Upgrade> refArray = UpgradesList.ul.upgradeList;
		for (int j = 0; j < refArray.Count; j++) {
			if (weaponOrTechName == refArray[j].upgradeName) {
				upgradeSprite.sprite = refArray[j].sprite; 
				weaponOrTechName = refArray[j].upgradeName;
				upgradeNameText.text = weaponOrTechName;
				upgradeDescription = refArray[j].description;
				upgradeDescText.text = upgradeDescription;
			}
		}
	}

	public void SelectUpgrade() {
		SoundManager.sm.buttonPress.Play();
		lvlPanel.gameObject.SetActive(false);
		Time.timeScale = 1f;
		WeaponSystem.Instance.ActivateWeaponSystem(_upgrade.upgradeName);
	}
}
