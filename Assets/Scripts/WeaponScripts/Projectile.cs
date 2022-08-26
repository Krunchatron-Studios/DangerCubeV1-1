using UnityEngine;
using MoreMountains.Tools;

public class Projectile : MonoBehaviour {

	public int projectileVelocity = 10;
	public ProjectileWeapon weapon;
	public Rigidbody2D projectileRb2D;
	public Vector3 targetPosition;
	public GameObject bloodSplash;
	public Vector3 direction;

	void OnTriggerEnter2D(Collider2D other) {
		ResolveProjectile(other);
	}
	public void Setup(Vector3 targetPos) {
		targetPosition = targetPos;
	}
	public void MoveProjectile() {
		Vector3 moveDirection = (targetPosition - transform.position).normalized;
		direction = moveDirection;
		projectileRb2D.AddForce(moveDirection * projectileVelocity * Time.deltaTime, ForceMode2D.Impulse);
	}
	public virtual void ResolveProjectile(Collider2D other) {
		if (other.CompareTag("Enemy")) {
			Debug.Log("Hello");
			IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
			hit.TakeDamage(weapon.weaponDamage);
			MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position, 
				weapon.weaponDamage.ToString(), Vector3.up, .2f);
			weapon.enemyKnockBack(direction, other.attachedRigidbody);
			bloodSplash = Instantiate(bloodSplash, other.transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
		if (other.CompareTag("Wall")) {
			Destroy(gameObject);
		}
	}
}
