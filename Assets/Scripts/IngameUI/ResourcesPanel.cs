using System;
using Newtonsoft.Json;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ResourcesPanel : MonoBehaviour {

	public TextMeshProUGUI bioLvl;
	public TextMeshProUGUI metLvl;
	public TextMeshProUGUI silLvl;

	public PlayerResources resRef;
	public int bioGooCurExp;
	public int metalCurExp;
	public int silicateCurExp;
	public Slider bioGooSlider, metalSlider, silicateSlider;
	public GameObject lvlPanel;
	
	public int bioGooCurrentLvl = 0;
	public int metalCurrentLvl = 0;
	public int silicateCurrentLvl = 0;

	public int maxResourceLvl = 20;
	
	public int[] bioGooResToLvlArray, metalResToLvlArray, silicateResToLvlArray;

	public int bioGooBaseExp = 5, metalBaseExp = 5, silicateBaseExp = 5;

	[SerializeField, Range(1, 2)] private float  expToNextModifier = 1.1f;

	private void Start() {
		PopulateResExpTiers(expToNextModifier);
	}

	private void Update() {
		UpdateResources();
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
		if (bioGooCurExp > bioGooResToLvlArray[bioGooCurrentLvl]) {
			resRef.bioGoo = 0;
			bioGooCurrentLvl++;
			Debug.Log("testing");
		}
		if (metalCurExp >= metalResToLvlArray[metalCurrentLvl]) {
			resRef.metal = 0;
			metalCurrentLvl++;
		}
		if (silicateCurExp >= silicateResToLvlArray[silicateCurrentLvl]) {
			resRef.silicate = 0;
			silicateCurrentLvl++;
		}
	}
}
