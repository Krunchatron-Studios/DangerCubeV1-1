using System.Collections;
using UnityEngine;
using MoreMountains.Feedbacks;

public class BurstFireWeapon : Weapon  {
	[Header("Projectile Vars")]
	public Vector2 enemyTarget;
	public TargetingSystem targetingSys;
	public GameObject firingPoint;
	public Projectile projectile;

	[Header("Firing Vars")]
	public float weaponRange = 3;
	public float reloadTimer = 2.0f;
	public float rateOfFire = 0.2f;
	public int ammo = 5;
	private bool _canFire;

	private void Start() {
		_canFire = true;
		targetingSys.circleCol2D.radius = weaponRange;
	}

	private void FixedUpdate() {
		if (_canFire) {
			StartCoroutine(BurstFire());
		}
	}
	
	public void AquireTarget(BaseEnemy enemy) {
		enemyTarget = enemy.transform.position;
	}

	IEnumerator BurstFire() {
		_canFire = false;
		for (int i = 0; i < ammo; i++) {
			FireWeapon(enemyTarget);
			yield return new WaitForSeconds(rateOfFire);
		}

		yield return new WaitForSeconds(reloadTimer);
		_canFire = true;
	}
		
	public virtual void FireWeapon(Vector3 targetPosition) {
		audioSource.Play();
		GameObject bullet = objectPooler.GetPooledGameObject();
		bullet.SetActive(true);
		bullet.transform.position = firingPoint.transform.position;
		projectile.Setup(targetPosition);
		MMCameraShakeEvent.Trigger(.1f, .1f, 40, 0, 0, 0, false);
		projectile.MoveProjectile();
	}
}
