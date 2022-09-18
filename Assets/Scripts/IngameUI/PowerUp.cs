using Interfaces;
using UnityEngine;

public class PowerUp : MonoBehaviour {
	public IUpgradeThingInterface weaponControls;
	public string upgradeName;
	public Upgrade targetUpgrade;
	public float increase;

	private void Awake() {
		weaponControls = targetUpgrade.GetComponent<IUpgradeThingInterface>();
	}
}
