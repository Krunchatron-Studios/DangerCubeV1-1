using Interfaces;
using MoreMountains.Tools;
using UnityEngine;

public class Weapon : Upgrade, IUpgradeThingInterface {
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

	public virtual void IncreaseDamage(float dmgIncrease) {
		weaponDamage += dmgIncrease;
		Debug.Log($"weapon dmg: {weaponDamage}");

	}
	public virtual void IncreaseAttackSpeed(float spdIncrease) {
		attackSpeed += spdIncrease;
	}

	public virtual void IncreaseKnock(float knkIncrease) {
		knockForce += knkIncrease;
	}
	public virtual void ModifyDmgType(string dmgType) {
		damageType = dmgType;
	}
	
	public virtual void ImproveReloadTimer(float timeReduction) {

	}

	public virtual void ChangeProjectile(GameObject newProjectile) {

	}
}
