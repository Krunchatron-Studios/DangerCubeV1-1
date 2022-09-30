
using System.Collections.Generic;
using UnityEngine;

public class LevelUpPanel : MonoBehaviour {
	public UpgradeButton[] upgradeButtons;
	public List<int> pickedIndexList;

	public void RefreshChoices() {
		int index = Random.Range(0, UpgradesList.ul.techList.Count);
		for (int i = 0; i < upgradeButtons.Length; i++) {
			UpgradeButton currentButton = upgradeButtons[i];
			index = Random.Range(0, UpgradesList.ul.techList.Count);
			for (int x = 0; x < pickedIndexList.Count; x++) {
				if (pickedIndexList[x] == index) {
					index = Random.Range(0, UpgradesList.ul.techList.Count);
				}
				if (pickedIndexList[x] == index) {
					index = Random.Range(0, UpgradesList.ul.techList.Count);
				}
				if (pickedIndexList[x] == index) {
					index = Random.Range(0, UpgradesList.ul.techList.Count);
				}
			}

			currentButton.upgrade = UpgradesList.ul.techList[index];
			pickedIndexList.Add(index);
		}
	}
}
