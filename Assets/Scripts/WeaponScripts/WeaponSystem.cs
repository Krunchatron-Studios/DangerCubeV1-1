using UnityEngine;

public class WeaponSystem : MonoBehaviour {
	[Header("Tech Unlocked")]

	public static WeaponSystem Instance;
	public Weapon[] cubeWeapons;

	private void Start() {
		Instance = this;
	}
	public void ActivateWeaponSystem(string weaponToActivate) {
		for (int i = 0; i < cubeWeapons.Length; i++) {
			if (cubeWeapons[i].upgradeName == weaponToActivate) {
				cubeWeapons[i].gameObject.SetActive(true);
			}
		}
	}
}
