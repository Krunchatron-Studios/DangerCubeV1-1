using MoreMountains.Tools;
using UnityEngine;

public class MineSlayerMine : ParticleProjectile {

	[Header("AcidMinePool goes here")]
	public MMSimpleObjectPooler minePooler;
	public MMSimpleObjectPooler detonationPooler;
	
	private void OnTriggerStay2D(Collider2D other) {

		if (other.CompareTag("Enemy")) {
			ResolveProjectile(other);
		}
	}
	
	public override void ResolveProjectile(Collider2D other) {
		if (other.CompareTag("Enemy")) {
			GameObject explosion = detonationPooler.GetPooledGameObject();
			explosion.gameObject.SetActive(true);
			explosion.transform.position = transform.position;
			
			IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
			hit.TakeDamage(weapon.weaponDamage, weapon.damageType);
			MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position, 
				weapon.weaponDamage.ToString(), Vector3.up, .2f);
			gameObject.SetActive(false);
		}
		if (other.CompareTag("Wall")) {
			gameObject.SetActive(false);
		}
	}
}
