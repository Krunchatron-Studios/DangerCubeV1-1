using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;

public class ProjectileWeapon : Weapon {
	
	[Header("Projectile Vars")]
	public List<GameObject> firingPoints;
	public GameObject projectile;
	public Vector2 enemyTarget;
	public TargetingSystem targetingSys;
	public Vector2 projectileScale;
	public bool doBulletsDecay;
	public float decayTimer;
	
	[Header("Firing Vars")]
	public bool canFire;
	public float nextFire;

	[Header("Muzzle and Impact Particles")]
	public MMSimpleObjectPooler muzzleFlashPool;

	private void Start() {
		canFire = true;
		targetingSys.circleCol2D.radius = upgradeRange;
		objectPooler = GetComponent<MMSimpleObjectPooler>();
		projectileScale = new Vector2(1, 1);
	}
	private void Update() {
		CanFireTimer();
	}
	public virtual void FireWeapon(Vector3 firePoint, Vector3 targetPosition) {
		GameObject muzzleFlash = muzzleFlashPool.GetPooledGameObject();
		Debug.Log($"flash: {muzzleFlash.name}");
		muzzleFlash.SetActive(true);
		muzzleFlash.transform.position = transform.position;
		
		audioSource.Play();
		
		GameObject spawnedBullet = objectPooler.GetPooledGameObject();
		Projectile bullet = spawnedBullet.GetComponent<Projectile>();
		bullet.transform.position = firePoint;
		bullet.Setup(targetPosition);
		nextFire = Time.time + attackSpeed;
		MMCameraShakeEvent.Trigger(.1f, .2f, 40, 0, 0, 0);
		bullet.gameObject.SetActive(true);
		bullet.damage = weaponDamage;
		bullet.transform.localScale = new Vector2(1.5f, 1.5f);
		bullet.MoveProjectile();
		if (doBulletsDecay) {
			StartCoroutine(BulletDecay(spawnedBullet));
		}
	}
	
	public virtual void CanFireTimer() {
		canFire = false;
		if (Time.time > nextFire) {
			canFire = true;
			for (int i = 0; i < firingPoints.Count; i++) {
				if (firingPoints[i].activeInHierarchy) {

					FireWeapon(firingPoints[i].transform.position, enemyTarget);
				}
			}
		}
	}
	
	public void AquireTarget(BaseEnemy enemy) {
		enemyTarget = enemy.transform.position;
	}

	public override void IncreaseProjectileScale(float scaleIncrease) {
		projectileScale = new Vector2(projectileScale.x + scaleIncrease,
			projectileScale.y + scaleIncrease);
	}

	public override void ChangeProjectile(GameObject newProjectile) {
		projectile = newProjectile;
	}

	IEnumerator BulletDecay(GameObject bullet) {
		yield return new WaitForSeconds(decayTimer);
		bullet.SetActive(false);
	}
}


