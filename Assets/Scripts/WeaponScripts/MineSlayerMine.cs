using MoreMountains.Tools;
using UnityEngine;

public class MineSlayerMine : ParticleProjectile {

	[Header("AcidMinePool goes here")]
	public MMSimpleObjectPooler minePooler;
	public MMSimpleObjectPooler blastPooler;
	public CircleCollider2D blastCircle;
	private float blastRadius;
	
	private void OnTriggerStay2D(Collider2D other) {
		blastRadius = weapon.weaponRange;
		if (other.CompareTag("Enemy")) {
			blastCircle.radius = weapon.weaponRange;
			ResolveProjectile(other);
		}
	}
	
	public override void ResolveProjectile(Collider2D other) {
		GameObject blast = PoolManager.pm.acidBlastPool.GetPooledGameObject();
		blast.gameObject.SetActive(true);
		blast.transform.position = transform.position;
		Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, blastRadius);
		foreach(Collider2D col in colliderArray) {
			if (other.CompareTag("Enemy")) {
				IDmgAndHpInterface hit = col.GetComponent<IDmgAndHpInterface>();
				hit.TakeDamage(weapon.weaponDamage, weapon.damageType);
				MMFloatingTextSpawnEvent.Trigger(0, col.attachedRigidbody.transform.position, 
					weapon.weaponDamage.ToString(), Vector3.up, .2f);
			}
		}
		gameObject.SetActive(false);
	}
}
