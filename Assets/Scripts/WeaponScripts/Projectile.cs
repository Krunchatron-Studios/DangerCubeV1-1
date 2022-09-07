using Interfaces;
using UnityEngine;
using MoreMountains.Tools;

public class Projectile : MonoBehaviour {

	public int projectileVelocity = 10;
	public ProjectileWeapon weapon;
	public Rigidbody2D projectileRb2D;
	public Vector3 targetPosition;
	public GameObject bloodSplash;
	public Vector3 direction;
	public float moveTime;

	void OnTriggerEnter2D(Collider2D other) {
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
			hit.TakeDamage(weapon.weaponDamage, weapon.damageType);
			MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position, 
				weapon.weaponDamage.ToString(), Vector3.up, .2f);
			bloodSplash = PoolManager.pm.bloodPool.GetPooledGameObject();
			bloodSplash.SetActive(true);
			bloodSplash.transform.position = other.transform.position;
			gameObject.SetActive(false);

		}
		
		if (other.CompareTag("Obstacle")) {
			ISmashThingsInterface hit = other.GetComponent<ISmashThingsInterface>();
			hit.DamageStructure(weapon.weaponDamage, weapon.damageType, other.transform.position);
			gameObject.SetActive(false);
		}
		if (other.CompareTag("Wall")) {
			gameObject.SetActive(false);
		}
	}
}
