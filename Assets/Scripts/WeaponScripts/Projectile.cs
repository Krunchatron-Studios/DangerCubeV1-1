using UnityEngine;
using MoreMountains.Tools;

public class Projectile : MonoBehaviour {

	public int projectileVelocity = 10;
	public Weapon weapon;
	public Rigidbody2D projectileRb2D;
	public Vector3 targetPosition;
	public GameObject wpnVFX;
	private GameObject _spawnedVFX;

	private void Start() {
		if (wpnVFX) {
			_spawnedVFX = Instantiate(wpnVFX, projectileRb2D.transform.position, Quaternion.identity);
			SpawnEffect();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		ResolveProjectile(other);
		if (other.CompareTag("Enemy")) {
			MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position, 
				weapon.weaponDamage.ToString(), Vector3.up, .2f);
		}
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
		}
		if (other.CompareTag("Wall")) {
			Destroy(gameObject);
		}
	}

	private void SpawnEffect() {
		Destroy(_spawnedVFX, 5f);
	}
	
}
