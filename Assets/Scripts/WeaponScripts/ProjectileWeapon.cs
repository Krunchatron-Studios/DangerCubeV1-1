using UnityEngine;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;

public class ProjectileWeapon : Weapon {
	
	[Header("Projectile Vars")]
	public GameObject firingPoint;
	public GameObject projectile;
	public Vector2 enemyTarget;
	public TargetingSystem targetingSys;
	
	[Header("Firing Vars")]
	public bool canFire;
	public float nextFire;

	private void Start() {
		canFire = true;
		targetingSys.circleCol2D.radius = upgradeRange;
		objectPooler = GetComponent<MMSimpleObjectPooler>();
	}
	private void Update() {
		CanFireTimer();
	}
	public virtual void FireWeapon(Vector3 firePoint, Vector3 targetPosition) {
		audioSource.Play();
		GameObject spawnedBullet = objectPooler.GetPooledGameObject();
		Projectile bullet = spawnedBullet.GetComponent<Projectile>();
		bullet.transform.position = firePoint;
		bullet.Setup(targetPosition);
		nextFire = Time.time + attackSpeed;
		MMCameraShakeEvent.Trigger(.1f, .2f, 40, 0, 0, 0, false);
		bullet.gameObject.SetActive(true);
		bullet.MoveProjectile();
	}
	
	public virtual void CanFireTimer() {
		canFire = false;
		if (Time.time > nextFire) {
			canFire = true;
			FireWeapon(firingPoint.transform.position, enemyTarget);
		}
	}
	
	public void AquireTarget(BaseEnemy enemy) {
		enemyTarget = enemy.transform.position;
	}

	public void ChangeProjectile(GameObject newProjectile) {
		projectile = newProjectile;
	}
}


