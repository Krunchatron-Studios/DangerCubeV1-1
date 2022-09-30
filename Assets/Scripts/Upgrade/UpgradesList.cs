using System.Collections.Generic;
using UnityEngine;

public class UpgradesList : MonoBehaviour {

	public static UpgradesList ul;
	private void Start() {
		ul = this;
	}

	public List<Upgrade> techList = new List<Upgrade>();

	public List<Upgrade> bioUpgradesMinor = new List<Upgrade>();
	public List<Upgrade> metalUpgradesMinor = new List<Upgrade>();
	public List<Upgrade> silicateUpgradesMinor = new List<Upgrade>();
	
	public List<Upgrade> bioUpgradesMajor = new List<Upgrade>();
	public List<Upgrade> metalUpgradesMajor = new List<Upgrade>();
	public List<Upgrade> silicateUpgradesMajor = new List<Upgrade>();

	public List<Upgrade> upgradeList = new List<Upgrade>();
}
