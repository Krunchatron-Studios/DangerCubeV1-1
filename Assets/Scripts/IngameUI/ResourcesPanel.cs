using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ResourcesPanel : MonoBehaviour {
	
	[Header("References")]
	public PlayerResources resRef;
	public GameObject lvlPanel;
	public LevelUpPanel levelUpPanel;
	
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
		bool lvlUp = false;
		if (bioGooCurExp >= bioGooResToLvlArray[bioGooCurrentLvl + 1]) {
			lvlPanel.SetActive(true);
			resRef.bioGoo = 0;
			bioGooCurrentLvl++;
			lvlUp = true;
		}
		if (metalCurExp >= metalResToLvlArray[metalCurrentLvl + 1]) {
			lvlPanel.SetActive(true);
			resRef.metal = 0;
			metalCurrentLvl++;
			lvlUp = true;
		}
		if (silicateCurExp >= silicateResToLvlArray[silicateCurrentLvl + 1]) {
			lvlPanel.SetActive(true);
			resRef.silicate = 0;
			silicateCurrentLvl++;
			lvlUp = true;
		}

		if (lvlUp) {
			Debug.Log("hoorah, lvl up!");
		}
	}
}
