using System.Collections;
using UnityEngine;
using MoreMountains.Feedbacks;

public class BurstFireWeapon : ProjectileWeapon  {
	
	[Header("Firing Vars")]
	public float reloadTimer = 2.0f;
	public int ammo = 5;

	private void Start() {
		canFire = true;
		targetingSys.circleCol2D.radius = upgradeRange;
	}

	private void FixedUpdate() {
		if (canFire) {
			StartCoroutine(BurstFire());
		}
	}
	
	IEnumerator BurstFire() {
		canFire = false;
		for (int i = 0; i < ammo; i++) {
			for (int j = 0; 0 < firingPoints.Count; j++) {
				if (firingPoints[j].activeInHierarchy) {
					FireWeapon(firingPoints[j].transform.position, enemyTarget);
				}
			}
			yield return new WaitForSeconds(attackSpeed);
		}
		yield return new WaitForSeconds(reloadTimer);
		canFire = true;
	}

	void FireWeapon(Vector3 firePoint, Vector3 targetPosition) {

		audioSource.Play();
		GameObject spawnedBullet = objectPooler.GetPooledGameObject();
		Projectile bullet = spawnedBullet.GetComponent<Projectile>();
		bullet.damage = weaponDamage;
		bullet.transform.position = firePoint;
		bullet.Setup(targetPosition);
		nextFire = Time.time + attackSpeed;
		MMCameraShakeEvent.Trigger(.1f, .2f, 40, 0, 0, 0, false);
		bullet.gameObject.SetActive(true);
		bullet.MoveProjectile();
	}

	public override void CanFireTimer() {
		
	}

	public override void ImproveReloadTimer(float timeReduction) {
		reloadTimer -= timeReduction;
	}

	public override void IncreaseAmmoClipSize(int ammoBonus) {
		ammo += ammoBonus;
	}
	
}
