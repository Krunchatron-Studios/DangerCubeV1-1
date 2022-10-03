using System.Collections.Generic;
using Managers;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UpgradeButton : MonoBehaviour {

	public Image upgradeSprite;
	public TextMeshProUGUI upgradeNameText;
	public TextMeshProUGUI upgradeDescText;
	
	public Upgrade upgrade;
	public LevelUpPanel lvlPanel;
	public MMTimeManager timeManager;

	private void Awake() {
		PopulateTech();
	}
	private void Start() {
		upgradeSprite = GetComponent<Image>();
	}
	public void PopulateTech() {
		int index = Random.Range(0, UpgradesList.ul.techList.Count);
		while(WeaponSystem.Instance.cubeWeapons[index].isActiveAndEnabled) {
			index = Random.Range(0, UpgradesList.ul.techList.Count);
		}
		upgrade = UpgradesList.ul.techList[index];
		Debug.Log($"tech populated: {upgrade.upgradeName}");
		UpdateLevelUpPanel();
	}
	public void UpdateLevelUpPanel() {
		List<Upgrade> refArray = UpgradesList.ul.techList;
		for (int i = 0; i < refArray.Count; i++) {
			if (upgrade.upgradeName == refArray[i].upgradeName) {
				upgradeSprite.sprite = refArray[i].upgradeSprite; 
				upgradeNameText.text = refArray[i].upgradeName;
				upgradeDescText.text = refArray[i].description;
			}
		}
	}
	public void SelectUpgrade() {
		SoundManager.sm.buttonPress.Play();
		lvlPanel.gameObject.SetActive(false);
		timeManager.SetTimescaleTo(1f);
		for (int i = 0; i < WeaponSystem.Instance.cubeWeapons.Length; i++) {
			if (upgrade.upgradeName == WeaponSystem.Instance.cubeWeapons[i].upgradeName) {
				WeaponSystem.Instance.cubeWeapons[i].gameObject.SetActive(true);
			}
		}
	}
}
