using Interfaces;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

public class Weapon : Upgrade, IUpgradeThingInterface {
	[Header("Main Weapon Vars")] 
	public float weaponDamage;
	public float attackSpeed;
	public string damageType;
	public float knockForce;

	public MMSimpleObjectPooler objectPooler;
	public MMF_Player player;

	public void Knockback (Collider2D other) {
		Rigidbody2D thisRigidBody = other.GetComponent<Rigidbody2D>();
		Vector3 difference = (other.transform.position - transform.position).normalized;
		Vector3 appliedForce = difference * knockForce;
		thisRigidBody.AddForce(transform.up * knockForce);
	}
	public virtual void IncreaseDamage(float dmgIncrease) {
		weaponDamage += dmgIncrease;
	}
	public virtual void IncreaseAttackSpeed(float spdIncrease) {
		attackSpeed -= spdIncrease;
	}
	public virtual void IncreaseKnock(float knkIncrease) {
		knockForce += knkIncrease;
	}
	public virtual void ModifyDmgType(string dmgType) {
		damageType = dmgType;
	}
	public virtual void ImproveReloadTimer(float timeReduction) {
		 // only to be overriden by BurstFire weapons
	}
	public virtual void IncreaseAmmoClipSize(int ammoBonus) {
		// overwritten by BurstFireWeapon
		// overwritten by Nanos
	}
	public virtual void IncreaseProjectileScale(float scaleIncrease) {
		// only to be overwritten by projectile weapons
	}
	public virtual void ChangeProjectile(GameObject newProjectile) {

	}
	public virtual void IncreaseRange(int amountToIncrease) {
		// overwritten by nanos
	}
}
