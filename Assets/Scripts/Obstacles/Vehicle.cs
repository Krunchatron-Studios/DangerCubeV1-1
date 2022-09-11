using Interfaces;
using MoreMountains.Feedbacks;
using UnityEngine;
using MoreMountains.Tools;

public class Vehicle : BasicStructure {
	public override void DamageStructure(float damageAmount, string damageType, Vector3 location) {
		shaker.Play();
		GetDustParticle(location);
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

			if (percentDestroyed <= 0.0f) {
				SoundManager.sm.burning1.Stop();
			}
			
		}
	}
}
