using UnityEngine;

public class Projectile : MonoBehaviour {

	public int projectileVelocity = 5;
	public Weapon weapon;
	public Rigidbody2D projectileRb2D;
	private void Update() {
		MoveProjectile(projectileRb2D);
	}

	void OnTriggerEnter2D(Collider2D other) {
		ResolveProjectile(other);
	}
	public void MoveProjectile(Rigidbody2D bulletRb2D) {
		if (!projectileRb2D) {
			projectileRb2D = bulletRb2D;
		}
		bulletRb2D.AddForce(Vector2.right * projectileVelocity, ForceMode2D.Impulse);
	}
	public void ResolveProjectile(Collider2D other) {
		if (other.CompareTag("Enemy")) {
				
			IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
			hit.TakeDamage(weapon.weaponDamage);
			Destroy(gameObject);
		}

		if (other.CompareTag("Wall")) {
			Destroy(gameObject);
		}
	}

	public void MoveProjectile() {
		Debug.Log(weapon.enemyTarget);
		Vector3 temp = Vector3.MoveTowards(weapon.firePoint1.transform.position, weapon.enemyTarget, projectileVelocity * Time.deltaTime);
		projectileRb2D.MovePosition(temp);
	}
}
