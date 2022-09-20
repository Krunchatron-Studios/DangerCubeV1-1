using System;
using Interfaces;
using UnityEngine;
using MoreMountains.Tools;
public class Projectile : MonoBehaviour {

	public int projectileVelocity = 10;
	public Weapon weapon;
	public float damage;
	public Rigidbody2D projectileRb2D;
	public Vector3 targetPosition;
	public Vector3 direction;

	private void Awake() {
		damage = weapon.weaponDamage;
		// Debug.Log($"damage: {damage}");
	}

	void OnTriggerEnter2D(Collider2D other) {
		// Debug.Log($"weapon dmg: {damage}");
		ResolveProjectile(other);
	}
	public void Setup(Vector3 targetPos) {
		targetPosition = targetPos;
		
	}
	public void MoveProjectile() {
		Vector3 moveDirection = (targetPosition - transform.position).normalized;
		direction = moveDirection;
		projectileRb2D.velocity = direction * projectileVelocity;
	}
	public virtual void ResolveProjectile(Collider2D other) {
		if (other.CompareTag("Enemy")) {
			IHurtThingsInterface hit = other.GetComponent<IHurtThingsInterface>();
			hit.TakeDamage(damage, weapon.damageType);
			MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position, 
				damage.ToString(), Vector3.up, .2f);
			
			BloodSplash(other);
			gameObject.SetActive(false);
		}
		
		if (other.CompareTag("Obstacle")) {
			ISmashThingsInterface hit = other.GetComponent<ISmashThingsInterface>();
			// Debug.Log($"Damage: {damage}");
			hit.DamageStructure(damage, weapon.damageType, other.transform.position);
			gameObject.SetActive(false);
		}
		if (other.CompareTag("Wall")) {
			gameObject.SetActive(false);
		}
	}

	private void BloodSplash(Collider2D other) {
		GameObject bloodSplash = PoolManager.pm.bloodPool.GetPooledGameObject();
		bloodSplash.SetActive(true);
		bloodSplash.transform.position = other.transform.position;
	}
}
