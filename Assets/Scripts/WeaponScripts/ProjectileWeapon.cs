using UnityEngine;
using MoreMountains.Feedbacks;

public class ProjectileWeapon : Weapon {

	[Header("Projectile Vars")]
	public GameObject[] firePointArray;
	public Transform projectile;
	public Vector2 enemyTarget;
	public TargetingSystem targetingSys;
	
	[Header("Firing Vars")]
	public float weaponRange = 3;
	public float rateOfFire = 2.0f;
	[SerializeField] private bool canFire = true;
	public float nextFire;

	private void Start() {
		targetingSys.circleCol2D.radius = weaponRange;
	}
	private void Update() {
		CanFireTimer();
	}
	public virtual void FireWeapon(Vector3 firePoint, Vector3 targetPosition) {
		audioSource.Play();
		Transform bulletTransform = Instantiate(projectile, firePoint, Quaternion.identity);
		Projectile bullet = bulletTransform.GetComponent<Projectile>();
		bullet.Setup(targetPosition);
		nextFire = Time.time + rateOfFire;
		bullet.MoveProjectile();
		MMCameraShakeEvent.Trigger(.1f, .2f, 40, 0, 0, 0, false);
	}
	
	public void CanFireTimer() {
		canFire = false;
		if (Time.time > nextFire) {
			canFire = true;
			for (int i = 0; i < firePointArray.Length; i++) {
				if (firePointArray[i].activeInHierarchy) {
					FireWeapon(firePointArray[i].transform.position, enemyTarget);
				}
			}
		}
	}
	
	public void AquireTarget(BaseEnemy enemy) {
		// Debug.Log($"aquired target: {enemy}");
		enemyTarget = enemy.transform.position;
	}
}
