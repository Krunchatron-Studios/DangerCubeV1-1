using System;
using UnityEngine;
using MoreMountains.Tools;

public class Projectile : MonoBehaviour {

	public int projectileVelocity = 10;
	public Weapon weapon;
	public Rigidbody2D projectileRb2D;
	[SerializeField] private GameObject projectileParticle;
	[SerializeField] private GameObject muzzleFlashParticle;
	public Vector3 targetPosition;
	public GameObject bloodSplash;
	private GameObject bullet;
	private GameObject flash;

	private void Start() {
		bullet = Instantiate(projectileParticle, projectileRb2D.transform.position, Quaternion.identity);
		flash = Instantiate(muzzleFlashParticle, projectileRb2D.transform.position, Quaternion.identity);
	}

	void OnTriggerEnter2D(Collider2D other) {
		ResolveProjectile(other);
		if (other.CompareTag("Enemy")) {
			MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position, 
				weapon.weaponDamage.ToString(), Vector3.up, .2f);
			bloodSplash = Instantiate(bloodSplash, other.transform.position, Quaternion.identity);
		}
	}

	private void Update() {
		bullet.transform.position = projectileRb2D.transform.position;
	}

	public void Setup(Vector3 targetPos) {
		targetPosition = targetPos;
	}
	public void MoveProjectile() {
		Vector3 moveDirection = (targetPosition - transform.position).normalized;
		projectileRb2D.AddForce(moveDirection * projectileVelocity * Time.deltaTime, ForceMode2D.Impulse);
	}
	public virtual void ResolveProjectile(Collider2D other) {
		if (other.CompareTag("Enemy")) {
			IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
			hit.TakeDamage(weapon.weaponDamage);
			Destroy(gameObject);
			Destroy(bullet);
			Destroy(flash);
		}
		if (other.CompareTag("Wall")) {
			Destroy(gameObject);
			Destroy(bullet);
			Destroy(flash);

		}
	}

	
}
