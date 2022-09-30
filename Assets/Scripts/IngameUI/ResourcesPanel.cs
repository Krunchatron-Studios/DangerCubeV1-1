using Managers;
using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesPanel : MonoBehaviour {
	
	[Header("References")]
	public PlayerResources resRef;
	public GameObject lvlPanel;
	public LevelUpPanel levelUpPanel;
	public MMTimeManager timeManager;

	[Header("Exp related stats")]
	public int bioGooBaseExp = 5, metalBaseExp = 5, silicateBaseExp = 5;
	public int bioGooCurExp, metalCurExp, silicateCurExp;
	public Slider bioGooSlider, metalSlider, silicateSlider;
	[SerializeField, Range(1, 2)] private float  expToNextModifier = 1.1f;
	
	[Header("Level related stats")]
	public int bioGooCurrentLvl = 0, metalCurrentLvl = 0, silicateCurrentLvl = 0;
	public int[] bioGooResToLvlArray, metalResToLvlArray, silicateResToLvlArray;
	public TextMeshProUGUI bioLvl, metLvl, silLvl;
	public int maxResourceLvl = 20;
	
	private void Start() {
		PopulateResExpTiers(expToNextModifier);
	}

	private void Update() {
		UpdateResources();
		LevelUpCheck();
	}
	public void PopulateResExpTiers(float multiplier) {

		print("resource goals populated");
		bioGooResToLvlArray = new int[maxResourceLvl];
		metalResToLvlArray = new int[maxResourceLvl];
		silicateResToLvlArray = new int[maxResourceLvl];
		
		bioGooResToLvlArray[1] = bioGooBaseExp;
		metalResToLvlArray[1] = metalBaseExp;
		silicateResToLvlArray[1] = silicateBaseExp;

		for (int i = 2; i < maxResourceLvl; i++) {
			bioGooResToLvlArray[i] = Mathf.FloorToInt(bioGooResToLvlArray[i - 1] * multiplier);
			metalResToLvlArray[i] = Mathf.FloorToInt(metalResToLvlArray[i - 1] * multiplier);
			silicateResToLvlArray[i] = Mathf.FloorToInt(silicateResToLvlArray[i - 1] * multiplier);
		}
	}
	public void UpdateResources() {
		
		bioGooCurExp = resRef.bioGoo;
		metalCurExp = resRef.metal;
		silicateCurExp = resRef.silicate;
		
		bioGooSlider.maxValue = bioGooResToLvlArray[bioGooCurrentLvl + 1];
		metalSlider.maxValue = metalResToLvlArray[metalCurrentLvl + 1];
		silicateSlider.maxValue = silicateResToLvlArray[silicateCurrentLvl + 1];
		
		bioGooSlider.value = bioGooCurExp;
		metalSlider.value = metalCurExp;
		silicateSlider.value = silicateCurExp;

		bioLvl.text = bioGooCurrentLvl.ToString();
		metLvl.text = metalCurrentLvl.ToString();
		silLvl.text = silicateCurrentLvl.ToString();
	}

	private void LevelUpCheck() {
		if (bioGooCurExp >= bioGooResToLvlArray[bioGooCurrentLvl + 1]) {
			SoundManager.sm.levelUp.Play();
			resRef.bioGoo = 0;
			bioGooCurrentLvl++;
			if (bioGooCurrentLvl % 5 == 0) {
				lvlPanel.SetActive(true);
				timeManager.SetTimescaleTo(0f);
			} else {
				for (int i = 0; i < WeaponSystem.Instance.cubeWeapons.Length; i++) {

					Weapon currentWeapon = WeaponSystem.Instance.cubeWeapons[i];
					Debug.Log($"name: {currentWeapon.name}");
					Debug.Log($"rng1: {currentWeapon.upgradeRange}");
					Debug.Log($"knock2: {currentWeapon.knockForce}");
					currentWeapon.IncreaseKnock(1f);
					currentWeapon.IncreaseRange(1);
					Debug.Log($"rng1: {currentWeapon.upgradeRange}");
					Debug.Log($"knock2: {currentWeapon.knockForce}");


				}
			}
			// levelUpPanel.RefreshChoices();
		}
		if (metalCurExp >= metalResToLvlArray[metalCurrentLvl + 1]) {
			SoundManager.sm.levelUp.Play();
			resRef.metal = 0;
			metalCurrentLvl++;
			if (metalCurrentLvl % 5 == 0) {
				lvlPanel.SetActive(true);
				timeManager.SetTimescaleTo(0f);

			} else {
				for (int i = 0; i < WeaponSystem.Instance.cubeWeapons.Length; i++) {
					Weapon currentWeapon = WeaponSystem.Instance.cubeWeapons[i];
					Debug.Log($"name: {currentWeapon.name}");
					Debug.Log($"dmg1: {currentWeapon.weaponDamage}");
					Debug.Log($"atks2: {currentWeapon.attackSpeed}");

					currentWeapon.IncreaseDamage(.5f);
					currentWeapon.IncreaseAttackSpeed(.05f);
					currentWeapon.IncreaseAmmoClipSize(3);
					Debug.Log($"dmg1: {currentWeapon.weaponDamage}");
					Debug.Log($"atks2: {currentWeapon.attackSpeed}");


				}
			}
			// levelUpPanel.RefreshChoices();
		}
		if (silicateCurExp >= silicateResToLvlArray[silicateCurrentLvl + 1]) {
			SoundManager.sm.levelUp.Play();
			resRef.silicate = 0;
			silicateCurrentLvl++;
			if (silicateCurrentLvl % 5 == 0) {
				lvlPanel.SetActive(true);
				timeManager.SetTimescaleTo(0f);
			} else {
				for (int i = 0; i < WeaponSystem.Instance.cubeWeapons.Length; i++) {
					Weapon currentWeapon = WeaponSystem.Instance.cubeWeapons[i];
					currentWeapon.ImproveReloadTimer(.4f);
					currentWeapon.IncreaseProjectileScale(.25f);
				}
			}
			// levelUpPanel.RefreshChoices();
		}

	}
}
