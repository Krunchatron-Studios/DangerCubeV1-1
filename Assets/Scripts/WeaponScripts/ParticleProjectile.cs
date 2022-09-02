using UnityEngine;
using MoreMountains.Tools;

public class ParticleProjectile : Projectile {
	[SerializeField] private GameObject projectileParticle;
	private GameObject _bullet;
	private Vector3 _bulletPos;
	private Vector3 _startPos;

	private void Start() {
		// _bulletPos = projectileRb2D.transform.position;
		// _bullet = objectPooler.GetPooledGameObject();
		// _bullet.SetActive(true);
		
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
			MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position, 
				weapon.weaponDamage.ToString(), Vector3.up, .2f);
			
			gameObject.SetActive(false);
			_bullet.SetActive(false);
		}
		if (other.CompareTag("Wall")) {
			gameObject.SetActive(false);
			_bullet.SetActive(false);

		}
	}
}
