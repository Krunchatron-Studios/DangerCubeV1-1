using Interfaces;
using UnityEngine;
using MoreMountains.Tools;

public class ParticleProjectile : Projectile {
	[SerializeField] private GameObject projectileParticle;
	private ParticleSystem _bullet;
	private Vector3 _bulletPos;
	private Vector3 _startPos;

	private void Update() {
		projectileParticle.transform.position = projectileRb2D.transform.position;
	}
	void OnTriggerEnter2D(Collider2D other) {
		float gatheredDmg = GameObject.FindGameObjectWithTag("PlasmaBurster").GetComponent<Weapon>().weaponDamage;
		ResolveProjectile(other);
	}
	public override void ResolveProjectile(Collider2D other) {
		if (other.CompareTag("Enemy")) {
			weapon.Knockback(other);

			IHurtThingsInterface hit = other.GetComponent<IHurtThingsInterface>();
			hit.TakeDamage(damage, weapon.damageType);
			MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position, 
				damage.ToString(), Vector3.up, .2f);
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
}
