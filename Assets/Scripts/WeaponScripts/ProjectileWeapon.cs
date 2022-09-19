using UnityEngine;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;

public class ProjectileWeapon : Weapon {
	
	[Header("Projectile Vars")]
	public GameObject firingPoint;
	public GameObject projectile;
	public Vector2 enemyTarget;
	public TargetingSystem targetingSys;
	public Vector2 projectileScale;
	
	[Header("Firing Vars")]
	public bool canFire;
	public float nextFire;

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
		Debug.Log($"bullet scale: {bullet.transform.localScale}");
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

	public override void IncreaseProjectileScale(float scaleIncrease) {
		projectileScale = new Vector2(projectileScale.x + scaleIncrease,
			projectileScale.y + scaleIncrease);
		Debug.Log($"proj scale: {projectileScale}");
	}

	public void ChangeProjectile(GameObject newProjectile) {
		projectile = newProjectile;
	}
}


