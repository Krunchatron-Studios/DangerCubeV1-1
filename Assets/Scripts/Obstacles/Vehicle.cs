using System.Collections;
using UnityEngine;
using MoreMountains.Feedbacks;

public class Vehicle : BasicStructure {

	private bool hasExploded = false;
	public override void DamageStructure(float damageAmount, string damageType, Vector3 location) {
		shaker.Play();
		GetDustParticle(location);
		CalculateDamage(damageAmount);
		DamageTiersCheck(location);
		percentDestroyed = currentIntegrity / maxIntegrity;
		CatchFire(damageType);
		
	}

	public override void DamageTiersCheck(Vector3 location) {

		if (percentDestroyed > 0 && percentDestroyed < stage3Threshold && stage3Dmg) {
			spriteRenderer.sprite = stage3Dmg;
		}
		if (percentDestroyed > stage3Threshold && percentDestroyed < stage2Threshold && stage2Dmg) {
			spriteRenderer.sprite = stage2Dmg;
			structureParent.evacuateThreshold--;
		}
		if (percentDestroyed > stage2Threshold && percentDestroyed < stage1Threshold && stage1Dmg) {
			spriteRenderer.sprite = stage1Dmg;
			GameObject glassShatter = StructureDamagePool.sdp.glassShatterPool.GetPooledGameObject();
			glassShatter.SetActive(true);
			glassShatter.transform.position = location;
			structureParent.evacuateThreshold--;
		}

	}
	public override void GetDustParticle(Vector3 location) {
		GameObject metalPoof = StructureDamagePool.sdp.metalPoofPool.GetPooledGameObject();
		metalPoof.SetActive(true);
		metalPoof.transform.position = location;
	}

	public virtual void CatchFire(string damageType) {
		if (damageType == "Fire" || damageType == "DeathRay") {

			if (percentDestroyed < 0.9f) {
				structureParent.fireAndSmokeDamageArray[0].SetActive(true);
			}

			if (percentDestroyed < 0.7f) {
				structureParent.fireAndSmokeDamageArray[1].SetActive(true);
			}

			if (percentDestroyed < 0.5f) {
				structureParent.fireAndSmokeDamageArray[2].SetActive(true);
				SoundManager.sm.burning1.Play();
			}

			if (percentDestroyed < 0.3f) {
				structureParent.fireAndSmokeDamageArray[3].SetActive(true);
			}

			if (percentDestroyed <= 0.0f && !hasExploded) {
				StartCoroutine(VehicleExplosion(3));
				MMCameraShakeEvent.Trigger(.5f, .5f, 40, 0, 0, 0, false);
				hasExploded = true;
			}
			
		}
	}

	IEnumerator VehicleExplosion(int explosions) {
		for (int i = 0; i < explosions; i++) {
			WaitForSeconds timer = new WaitForSeconds(.15f);
			yield return timer;
			GameObject explosion = StructureDamagePool.sdp.carExplosionPool.GetPooledGameObject();
			explosion.SetActive(true);
			SoundManager.sm.explosion1.Play();
			explosion.transform.position = structureParent.transform.position;
		}
		gameObject.SetActive(false);
	}
}
