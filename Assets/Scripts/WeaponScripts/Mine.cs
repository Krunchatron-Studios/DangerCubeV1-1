using UnityEngine;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;

public class Mine : ParticleProjectile {
	[Header("Mine Specific Stats")]
	public float explosionRadius = 3f;
	[Header("Explosion particle")] 
	public ParticleSystem explosionParticle;
	private void Awake() {
		explosionRadius = weapon.weaponRange;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Enemy")) {
			Explode();
		}
	}

	private void Explode() {
		Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
		foreach (Collider2D col in colliderArray) {
			IDmgAndHpInterface hit = col.GetComponent<IDmgAndHpInterface>();
			hit.TakeDamage(weapon.weaponDamage, weapon.damageType);
			MMCameraShakeEvent.Trigger(.15f, .4f, 60, 0, 0, 0, false);
			explosionParticle.Play();
		}
		gameObject.SetActive(false);
	}

}
