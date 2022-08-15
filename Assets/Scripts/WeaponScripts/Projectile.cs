using System;
using UnityEngine;

public class Projectile : MonoBehaviour {
	public Rigidbody2D projectileRb2D;
	public int projectileVelocity = 5;
	public Weapon weapon;

	private void Start() {
		MoveProjectile();
	}

	void OnTriggerEnter2D(Collider2D other) {
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
		Vector3 temp = Vector3.MoveTowards(weapon.firePoint1.transform.position, GameManager.gm.mousePosition, projectileVelocity * Time.deltaTime);
		Debug.Log("Mouse Position: " + GameManager.gm.mousePosition);
		projectileRb2D.MovePosition(temp);
	}
}
