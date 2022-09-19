
using UnityEngine;

public class LevelUpPanel : MonoBehaviour {

	public UpgradeButton[] upgradeButtons;

	public void RefreshChoices() {
		Debug.Log("test");
		upgradeButtons[0].GenerateMinorBioUpgrade();
		upgradeButtons[1].GenerateMinorMetalUpgrade();
		upgradeButtons[2].GenerateMinorSilicateUpgrade();
		upgradeButtons[3].GenerateMajorUpgrade();
		//upgradeButtons[4].GenerateMajorUpgrade("place holder");
	}
	
	
}
