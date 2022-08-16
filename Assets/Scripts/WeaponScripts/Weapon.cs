using UnityEngine;

public class Weapon : MonoBehaviour {
	
	[Header("Main Weapon Vars")]
	public string weaponName;
	public int weaponDamage = 1;
	public float weaponRange = 3;
	
	[Header("Firing Vars")]
	public int weaponLevel = 1;
	public float rateOfFire = 1.0f;
	private bool _canFire = true;
	private float _nextFire;
	
	[Header("Projectile Vars")]
	public GameObject firePoint1, firePoint2, firePoint3, firePoint4;
	public Projectile projectile;
	public Vector2 enemyTarget;
	
	[Header("Upgrade Related")]
	public string[] weaponUpgrades;
	public TargetingSystem targetingSys;

	private void FixedUpdate() {
		CanFireTimer();
	}
	public void FireWeapon() {
		Projectile bullet = Instantiate(projectile, firePoint1.transform.position, Quaternion.identity);
		Rigidbody2D bulletRb2D = bullet.GetComponent<Rigidbody2D>();
		bullet.MoveProjectile(bulletRb2D);
		_nextFire = Time.time + rateOfFire;
	}

	public void CanFireTimer() {
		_canFire = false;
		if (Time.time > _nextFire) {
			_canFire = true;
			FireWeapon();
		}
	}

	public void AquireTarget(BaseEnemy enemy) {
		enemyTarget = enemy.transform.position;
		Debug.Log("target enemy" + enemyTarget);
	}
}
