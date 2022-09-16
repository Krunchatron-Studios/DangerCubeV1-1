using Interfaces;
using MoreMountains.Tools;
using UnityEngine;

public class Weapon : MonoBehaviour, IUpgradeThingInterface {

	public Sprite weaponSprite;
	private AudioClip _weaponSound;
	public AudioSource audioSource;
	[Header("Upgrade Variables")] 
	public int upgradeLevel = 0;
	public string thisUpgradesTier;
	public string weaponType;
	[Header("Main Weapon Vars")] 
	public string weaponName;
	public string weaponDescription;
	public float weaponDamage;
	public string damageType;
	public float knockForce;

	public MMSimpleObjectPooler objectPooler;
	public void Knockback (Collider2D other) {
		Rigidbody2D thisRigidBody = other.GetComponent<Rigidbody2D>();
		Vector3 difference = (other.transform.position - transform.position).normalized;
		Vector3 appliedForce = difference * knockForce;
		thisRigidBody.AddForce(transform.up * knockForce);
	}

	public void UpgradeWeapon(string weapon) {
		// add upgrade logic
	}

	public virtual void LevelUp(string weapon) {
		// add level up logic
	}
}
