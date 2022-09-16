using System.Collections;
using UnityEngine;
using MoreMountains.Feedbacks;

public class BurstFireWeapon : ProjectileWeapon  {
	
	[Header("Firing Vars")]
	public float reloadTimer = 2.0f;
	public int ammo = 5;

	private void Start() {
		canFire = true;
		targetingSys.circleCol2D.radius = weaponRange;
	}

	private void FixedUpdate() {
		if (canFire) {
			StartCoroutine(BurstFire());
		}
	}
	
	IEnumerator BurstFire() {
		canFire = false;
		for (int i = 0; i < ammo; i++) {
			FireWeapon(enemyTarget);
			yield return new WaitForSeconds(rateOfFire);
		}

		yield return new WaitForSeconds(reloadTimer);
		canFire = true;
	}

	void FireWeapon(Vector3 targetPosition) {

		audioSource.Play();
		GameObject spawnedBullet = objectPooler.GetPooledGameObject();
		Projectile bullet = spawnedBullet.GetComponent<Projectile>();
		bullet.transform.position = firingPoint.transform.position;
		bullet.Setup(targetPosition);
		nextFire = Time.time + rateOfFire;
		MMCameraShakeEvent.Trigger(.1f, .2f, 40, 0, 0, 0, false);
		bullet.gameObject.SetActive(true);
		bullet.MoveProjectile();
	}

	public override void CanFireTimer() {
		// can fire
	}
}
