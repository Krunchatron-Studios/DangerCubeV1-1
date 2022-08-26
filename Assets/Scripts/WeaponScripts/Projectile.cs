using UnityEngine;
using MoreMountains.Tools;

public class Projectile : MonoBehaviour {

	public int projectileVelocity = 10;
	public ProjectileWeapon weapon;
	public Rigidbody2D projectileRb2D;
	public Vector3 targetPosition;
	public GameObject bloodSplash;
	private float _distance;
	private Vector3 _direction;
	
	private void Update() {
		_distance = Vector3.Distance(weapon.transform.position, transform.position);
		if (_distance > weapon.weaponRange) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		ResolveProjectile(other);
		if (other.CompareTag("Enemy")) {
			weapon.enemyKnockBack(_direction, other.attachedRigidbody);
			MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position, 
				weapon.weaponDamage.ToString(), Vector3.up, .2f);
			bloodSplash = Instantiate(bloodSplash, other.transform.position, Quaternion.identity);
		}
	}

	

	public void Setup(Vector3 targetPos) {
		targetPosition = targetPos;
	}
	public void MoveProjectile() {
		Vector3 moveDirection = (targetPosition - transform.position).normalized;
		_direction = moveDirection;
		projectileRb2D.AddForce(moveDirection * projectileVelocity * Time.deltaTime, ForceMode2D.Impulse);
	}
	public virtual void ResolveProjectile(Collider2D other) {
		if (other.CompareTag("Enemy")) {
			IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
			hit.TakeDamage(weapon.weaponDamage);
			Destroy(gameObject);
		}
		if (other.CompareTag("Wall")) {
			Destroy(gameObject);
		}
	}
}
