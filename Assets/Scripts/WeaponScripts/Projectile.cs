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
<<<<<<< HEAD
=======
	public void MoveProjectile() {
		Vector3 temp = Vector3.MoveTowards(weapon.firePoint1.transform.position, GameManager.gm.mousePosition, projectileVelocity * Time.deltaTime);
		Debug.Log("Mouse Position: " + GameManager.gm.mousePosition);
		projectileRb2D.MovePosition(temp);
	}
>>>>>>> 9bf25595fba0aa9f967d2f1fa87791bd13d91755
}
