using UnityEngine;

public class Weapon : MonoBehaviour {

	public Sprite weaponSprite;
	[Header("Main Weapon Vars")]
	public string weaponName;
	public string weaponDescription;
	public int weaponDamage = 1;
	public float weaponRange = 3;
	
	[Header("Firing Vars")]
	public int weaponLevel = 1;
	public float rateOfFire = 1.0f;
	public bool canFire = true;
	public float nextFire;
	
	[Header("Projectile Vars")]
	public GameObject firePoint1, firePoint2, firePoint3, firePoint4;
	public Transform projectile;
	public Vector2 enemyTarget;
	
	[Header("Upgrade Related")]
	public string[] weaponUpgrades;
	public TargetingSystem targetingSys;

	private void FixedUpdate() {
		CanFireTimer();
	}
	public virtual void FireWeapon(Vector3 firePoint, Vector3 targetPosition) {
		Transform bulletTransform = Instantiate(projectile, firePoint, Quaternion.identity);
		Projectile bullet = bulletTransform.GetComponent<Projectile>();
		bullet.Setup(targetPosition);
		nextFire = Time.time + rateOfFire;
		bullet.MoveProjectile();
	}

	public void CanFireTimer() {
		canFire = false;
		if (Time.time > nextFire) {
			canFire = true;
			FireWeapon(firePoint1.transform.position, enemyTarget);
		}
	}

	public void AquireTarget(BaseEnemy enemy) {
		enemyTarget = enemy.transform.position;
	}
}
