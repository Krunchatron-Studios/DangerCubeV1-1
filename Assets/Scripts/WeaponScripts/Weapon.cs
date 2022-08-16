using UnityEngine;
using UnityEngine.Serialization;

public class Weapon : MonoBehaviour {
	
	[Header("Main Weapon Vars")]
	public string weaponName;
	public int weaponDamage = 1;
	public float weaponRange = 3;
	
	[Header("Firing Vars")]
	public int weaponLevel = 1;
	public int rateOfFire = 50;
	private bool _canFire = true;
	private int _canFireTimer = 0;
	
	[Header("Projectile Vars")]
	public GameObject firePoint1, firePoint2, firePoint3, firePoint4;
	public Projectile projectile;
	public Vector2 enemyTarget;
	
	[Header("Upgrade Related")]
	public string[] weaponUpgrades;
	public TargetingSystem targetingSys;

	private void FixedUpdate() {
		if (_canFire) {
			FireWeapon();
		} 
		CanFireTimer();	
		
	}
	public void FireWeapon() {
		_canFire = false;
		Projectile bullet = Instantiate(projectile, firePoint1.transform.position, Quaternion.identity);
		Rigidbody2D bulletRb2D = bullet.GetComponent<Rigidbody2D>();
		bullet.MoveProjectile(bulletRb2D);
	}

	public void CanFireTimer() {
		_canFireTimer++;
		if (_canFireTimer < rateOfFire) {
			_canFire = false;
		}
		if (_canFireTimer >= rateOfFire) {
			_canFire = true;
		}
	}

	public void AquireTarget(BaseEnemy enemy) {
		enemyTarget = enemy.transform.position;
	}
}
