using Interfaces;
using UnityEngine;
public class Upgrade : MonoBehaviour {
	private IUpgradeThingInterface _interface;
	public string upgradeName;
	public string category;
	public Sprite sprite;
	public string description;
	
	private void Start() {
		_interface = WeaponSystem.Instance.GetComponent<IUpgradeThingInterface>();
		Weapon[] cubeWeapons = WeaponSystem.Instance.cubeWeapons;
		if (category == "Major") {
			for (int i = 0; i < WeaponSystem.Instance.cubeWeapons.Length; i++) {
				if (!cubeWeapons[i].gameObject.activeInHierarchy && cubeWeapons[i].weaponName == upgradeName) {
					cubeWeapons[i].gameObject.SetActive(true);
				} 
			}
		}
		
		if (category == "Minor") {
			for (int i = 0; i < WeaponSystem.Instance.cubeWeapons.Length; i++) {
				if (cubeWeapons[i].gameObject.activeInHierarchy && cubeWeapons[i].weaponName == upgradeName) {
					_interface.LevelUp(upgradeName);
				}
			}
		}
	}

}
