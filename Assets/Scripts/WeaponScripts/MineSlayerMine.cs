using Interfaces;
using Managers;
using MoreMountains.Tools;
using UnityEngine;

public class MineSlayerMine : ParticleProjectile {

	[SerializeField] private float blastRadius = 3f;
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Enemy")) {
			ResolveProjectile(other);
		}
	}
	public override void ResolveProjectile(Collider2D other) {
		GameObject blast = PoolManager.pm.acidBlastPool.GetPooledGameObject();
		blast.SetActive(true);
		blast.transform.position = other.transform.position;
		HitBlast();
		gameObject.SetActive(false);
	}
	private void HitBlast() {
		SoundManager.sm.mineSlayerMine.Play();
		Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, blastRadius);
		foreach(Collider2D col in colliderArray) {
			if (col.CompareTag("Enemy")) {
				IHurtThingsInterface hit = col.GetComponent<IHurtThingsInterface>();
				hit.TakeDamage(weapon.weaponDamage, weapon.damageType);
				MMFloatingTextSpawnEvent.Trigger(0, col.attachedRigidbody.transform.position, 
					weapon.weaponDamage.ToString(), Vector3.up, .2f);
			}
		}
	}
}
