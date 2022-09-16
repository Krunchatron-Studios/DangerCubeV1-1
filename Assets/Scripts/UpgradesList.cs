using System;
using UnityEngine;

public class UpgradesList : MonoBehaviour {

	public static UpgradesList ul;
	private void Start() {
		ul = this;
	}

	public Upgrade[] bioUpgradesMinor;
	public Upgrade[] metalUpgradesMinor;
	public Upgrade[] silicateUpgradesMinor;
	
	public Upgrade[] bioUpgradesMajor;
	public Upgrade[] metalUpgradesMajor;
	public Upgrade[] silicateUpgradesMajor;

	public Upgrade[] referenceArray;
}
