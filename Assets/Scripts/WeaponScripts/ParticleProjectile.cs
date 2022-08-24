using UnityEngine;

public class ParticleProjectile : Projectile {
	[SerializeField] private GameObject projectileParticle;
	[SerializeField] private GameObject muzzleFlashParticle;
	private GameObject _bullet;
	private GameObject _flash;
	private Vector3 _bulletPos;
	
	private void Start() {
		_bulletPos = projectileRb2D.transform.position;
		_bullet = Instantiate(projectileParticle, _bulletPos, Quaternion.identity);
		_flash = Instantiate(muzzleFlashParticle, _bulletPos, Quaternion.identity);
	}
	
	private void Update() {
		_bullet.transform.position = projectileRb2D.transform.position;
	}

	void OnTriggerEnter2D(Collider2D other) {
		ResolveProjectile(other);
	}
	
	public override void ResolveProjectile(Collider2D other) {
		if (other.CompareTag("Enemy")) {
			IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
			hit.TakeDamage(weapon.weaponDamage);
			Destroy(gameObject);
			Destroy(_bullet);
			Destroy(_flash);
		}
		if (other.CompareTag("Wall")) {
			Destroy(gameObject);
			Destroy(_bullet);
			Destroy(_flash);
		}
	}
}
