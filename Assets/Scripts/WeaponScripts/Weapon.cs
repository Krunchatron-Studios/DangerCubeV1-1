using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour {

	public string weaponName;
	public int weaponDamage = 0;
	public float weaponRange = 0;
	public int weaponLevel = 0;
	public float rateOfFire = 0f;
	public GameObject firePoint1, firePoint2, firePoint3, firePoint4;

	public Projectile projectile;
	public string[] weaponUpgrades;

	private void Update() {
		if (Keyboard.current.spaceKey.wasPressedThisFrame) {
			FireWeapon();
		}
	}

	public void FireWeapon() {
		// create the bullet
		Instantiate(projectile, firePoint1.transform.position, Quaternion.identity);
		projectile.MoveProjectile();
		
		// bullet moves toward target point
		// bullet destroys self after contact
	}
}
