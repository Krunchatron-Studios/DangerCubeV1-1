using UnityEngine;

public class Weapon : MonoBehaviour {

	public string weaponName;
	public int weaponDamage = 0;
	public float weaponRange = 0;
	public int weaponLevel = 0;
	public float rateOfFire = 0f;

	public GameObject projectile;
	public GameObject[] firePoints;
	public string[] weaponUpgrades;
}
