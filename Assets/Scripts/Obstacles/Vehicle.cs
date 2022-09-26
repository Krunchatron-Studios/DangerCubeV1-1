using System.Collections;
using Managers;
using UnityEngine;
using MoreMountains.Feedbacks;

public class Vehicle : BasicStructure {

	private bool _hasExploded = false;
	public AudioSource[] explosionAudio;
	public MMF_Player carExplosionShaker;
	public override void DamageStructure(float damageAmount, string damageType, Vector3 location) {
		shaker.Play();
		GetDustParticle(location);
		CalculateDamage(damageAmount);
		percentDestroyed = currentIntegrity / maxIntegrity;
		DamageTiersCheck1(location);
		DamageTiersCheck2(location);
		DamageTiersCheck3(location);
		CatchFire(damageType);
	}
	public override void DamageTiersCheck1(Vector3 location) {
		if (percentDestroyed < stage1Threshold && stage1Dmg) {
			spriteRenderer.sprite = stage1Dmg;
			GameObject rockShatter = StructureDamagePool.sdp.rockShatterPool.GetPooledGameObject();
			rockShatter.SetActive(true);
			rockShatter.transform.position = location;
			structureParent.evacuateThreshold--;
		}
	}
	public override void DamageTiersCheck2(Vector3 location) {
		if (percentDestroyed < stage2Threshold && stage2Dmg) {
			spriteRenderer.sprite = stage2Dmg;
			structureParent.evacuateThreshold--;
		}
	}
	public override void DamageTiersCheck3(Vector3 location) {
		if (percentDestroyed < stage1Threshold && stage1Dmg) {
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
	public override void CatchFire(string damageType) {
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
			if (percentDestroyed <= 0.0f && !_hasExploded) {
				StartCoroutine(VehicleExplosion(3));
				GameObject rubble = PoolManager.pm.sMetalPool.GetPooledGameObject();
				rubble.SetActive(true);
				carExplosionShaker.GetComponent<MMF_Player>()?.PlayFeedbacks(transform.position, 2f);
				rubble.transform.position = transform.position;
				_hasExploded = true;
			}
		}
	}
	IEnumerator VehicleExplosion(int explosions) {
		for (int i = 0; i < explosions; i++) {
			WaitForSeconds timer = new WaitForSeconds(.15f);
			yield return timer;
			GameObject explosion = StructureDamagePool.sdp.carExplosionPool.GetPooledGameObject();
			explosion.SetActive(true);
			explosionAudio[i].Play();
			explosion.transform.position = structureParent.transform.position;
		}
		gameObject.SetActive(false);
	}
}
