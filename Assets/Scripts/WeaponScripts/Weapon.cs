using Interfaces;
using MoreMountains.Tools;
using UnityEngine;

public class Weapon : Upgrade, IUpgradeThingInterface {
	
	public int upgradeLevel = 0;
	[Header("Main Weapon Vars")] 
	public float weaponDamage;
	public float attackSpeed;
	public string damageType;
	public float knockForce;

	public MMSimpleObjectPooler objectPooler;
	public void Knockback (Collider2D other) {
		Rigidbody2D thisRigidBody = other.GetComponent<Rigidbody2D>();
		Vector3 difference = (other.transform.position - transform.position).normalized;
		Vector3 appliedForce = difference * knockForce;
		thisRigidBody.AddForce(transform.up * knockForce);
	}
	public virtual void UpgradeWeapon(string weapon, int bonusDamage) {
		Weapon currentWeapon;
		for (int i = 0; i < WeaponSystem.Instance.cubeWeapons.Length; i++) {
			currentWeapon = WeaponSystem.Instance.cubeWeapons[i];
			if (currentWeapon.upgradeName == weapon &&
			    !currentWeapon.gameObject.activeInHierarchy) {
				weaponDamage += bonusDamage;
			}
		}
		upgradeLevel++;
	}
}
