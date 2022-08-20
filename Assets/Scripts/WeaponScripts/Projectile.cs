using System;
using UnityEngine;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;

public class Projectile : MonoBehaviour {

	public int projectileVelocity = 10;
	public Weapon weapon;
	public Rigidbody2D projectileRb2D;
	public Vector3 targetPosition;

	void OnTriggerEnter2D(Collider2D other) {
		ResolveProjectile(other);
	}
	public void Setup(Vector3 targetPos) {
		targetPosition = targetPos;
	}
	public void MoveProjectile() {
		Vector3 moveDirection = (targetPosition - transform.position).normalized;
		projectileRb2D.AddForce(moveDirection * projectileVelocity * Time.deltaTime, ForceMode2D.Impulse);
	}
	public void ResolveProjectile(Collider2D other) {
		if (other.CompareTag("Enemy")) {
			MMFloatingTextSpawnEvent.Trigger(0, other.transform.position,
										weapon.weaponDamage.ToString(),
									Vector3.up, .5f);
			IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
			hit.TakeDamage(weapon.weaponDamage);
			Destroy(gameObject);
		}
		if (other.CompareTag("Wall")) {
			Destroy(gameObject);
		}
	}
	
}
