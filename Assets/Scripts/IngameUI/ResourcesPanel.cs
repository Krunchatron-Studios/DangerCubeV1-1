using System;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ResourcesPanel : MonoBehaviour {

	public PlayerResources resRef;
	public int bioGooCurExp;
	public int metalCurExp;
	public int silicateCurExp;
	public Slider bioGooSlider, metalSlider, silicateSlider;
	
	public int bioGooCurrentLvl = 0;
	public int metalCurrentLvl = 0;
	public int silicateCurrentLvl = 0;

	public int maxResourceLvl = 20;
	
	public int[] bioGooResToLvlArray, metalResToLvlArray, silicateResToLvlArray;

	public int bioGooBaseExp = 20, metalBaseExp = 20, silicateBaseExp = 20;

	[SerializeField, Range(1, 2)] private float  expToNextModifier = 1.1f;

	private void Start() {
		PopulateResExpTiers(expToNextModifier);
		bioGooCurExp = resRef.bioGoo;
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
	}
}
