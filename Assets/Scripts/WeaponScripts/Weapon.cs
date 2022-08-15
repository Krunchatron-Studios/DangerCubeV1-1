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

	// ReSharper disable Unity.PerformanceAnalysis
	public void FireWeapon() {
		Projectile bullet = Instantiate(projectile, firePoint1.transform.position, Quaternion.identity);
		Rigidbody2D bulletRb2D = bullet.GetComponent<Rigidbody2D>();
		bullet.MoveProjectile(bulletRb2D);
	}
}
