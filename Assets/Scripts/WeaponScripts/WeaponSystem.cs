using UnityEngine;

public class WeaponSystem : MonoBehaviour {

	public static WeaponSystem Instance;
	public Weapon[] cubeWeapons;

	private void Start() {
		Instance = this;
	}
	public void ActivateWeaponSystem(string weaponToActivate) {
		// Debug.Log(cubeWeapons.ToString());
		for (int i = 0; i < cubeWeapons.Length; i++) {
			if (cubeWeapons[i].weaponName == weaponToActivate) {
				cubeWeapons[i].gameObject.SetActive(true);
			}
		}
	}
}
