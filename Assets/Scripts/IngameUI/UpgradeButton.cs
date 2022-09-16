using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour {
	public LevelUpPanel lvlPanel;
	public string weaponOrTechName;
	public Image upgradeSprite;
	public string upgradeDescription = "this is a test string description";
	public TextMeshProUGUI upgradeNameText;
	public TextMeshProUGUI upgradeDescText;

	
	private void Start() {
		upgradeSprite.sprite = GetComponent<SpriteRenderer>().sprite;
		lvlPanel = FindObjectOfType<LevelUpPanel>();
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
	
	public void UpdateLevelUpPanel() {
		Upgrade[] refArray = UpgradesList.ul.referenceArray;
		for (int j = 0; j < refArray.Length; j++) {
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
		WeaponSystem.Instance.ActivateWeaponSystem(weaponOrTechName);
		lvlPanel.gameObject.SetActive(false);
		Time.timeScale = 1f;
	}
}
