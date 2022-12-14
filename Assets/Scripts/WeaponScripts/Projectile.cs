using Interfaces;
using Managers;
using UnityEngine;
using MoreMountains.Tools;
public class Projectile : MonoBehaviour {

	public int projectileVelocity = 10;
	public ProjectileWeapon weapon;
	public float damage;
	public Rigidbody2D projectileRb2D;
	public Vector3 targetPosition;
	public Vector3 direction;
	public GameObject impact;

	private void Awake() {
		damage = weapon.weaponDamage;
	}

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
			hit.TakeDamage(damage, weapon.damageType);
			MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position, 
				damage.ToString(), Vector3.up, .2f);
			BloodSplash(other);
			gameObject.SetActive(false);
			
		}
		if (other.CompareTag("Obstacle")) {
			ISmashThingsInterface hit = other.GetComponent<ISmashThingsInterface>();
			hit.DamageStructure(damage, weapon.damageType, other.transform.position);
			gameObject.SetActive(false);
		}
		if (other.CompareTag("Wall")) {
			gameObject.SetActive(false);
		}
	}

	public void BloodSplash(Collider2D other) {
		GameObject bloodSplash = PoolManager.pm.bloodPool.GetPooledGameObject();
		bloodSplash.SetActive(true);
		bloodSplash.transform.position = other.transform.position;
	}

	public void TriggerImpact(GameObject impact) {
		impact.SetActive(true);
		impact.transform.position = transform.position;
	}

}
