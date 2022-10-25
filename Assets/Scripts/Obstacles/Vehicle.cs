using System.Collections;
using Interfaces;
using Managers;
using UnityEngine;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;

public class Vehicle : BasicStructure {

	public float blastRadius = 3f;
	public float blastDamage = 2f;
	private bool _hasExploded = false;
	private bool _closeToExploding = false;
	public MMF_Player carExplosionShaker;
	public override void DamageStructure(float damageAmount, string damageType, Vector3 location) {
		shaker.Play();
		GetDustParticle(location);
		CalculateDamage(damageAmount);
		percentDestroyed = currentIntegrity / maxIntegrity;
		DamageTiersCheck3(location);
		DamageTiersCheck2(location);
		DamageTiersCheck1(location);
		
		CatchFire(damageType);
	}
	public override void DamageTiersCheck1(Vector3 location) {
		if (percentDestroyed < stage1Threshold && stage1Dmg && percentDestroyed > stage2Threshold) {
			spriteRenderer.sprite = stage1Dmg;
			GameObject rockShatter = StructureDamagePool.sdp.rockShatterPool.GetPooledGameObject();
			rockShatter.SetActive(true);
			rockShatter.transform.position = location;
			structureParent.evacuateThreshold--;
		}
	}
	public override void DamageTiersCheck2(Vector3 location) {
		if (percentDestroyed < stage2Threshold && stage2Dmg && percentDestroyed > stage3Threshold) {
			spriteRenderer.sprite = stage2Dmg;
			structureParent.evacuateThreshold--;
		}
	}
	public override void DamageTiersCheck3(Vector3 location) {
		if (percentDestroyed < stage1Threshold && stage1Dmg && percentDestroyed > 0) {
			spriteRenderer.sprite = stage3Dmg;
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
				if (_closeToExploding == false) {
					SoundManager.sm.explosionSounds[4].Play();
					_closeToExploding = true;
				}
			}
			if (percentDestroyed <= 0.0f && !_hasExploded) {
				StartCoroutine(VehicleExplosion(3));
				GameObject rubble = PoolManager.pm.lMetalPool.GetPooledGameObject();
				rubble.SetActive(true);
				carExplosionShaker.GetComponent<MMF_Player>()?.PlayFeedbacks(transform.position, 2f);
				rubble.transform.position = transform.position;
				_hasExploded = true;
				SoundManager.sm.burning1.Stop();
				ResolveExplosion(blastDamage);

			}
		}
	}
	IEnumerator VehicleExplosion(int explosions) {
		for (int i = 0; i < explosions; i++) {
			WaitForSeconds timer = new WaitForSeconds(.15f);
			yield return timer;
			GameObject explosion = StructureDamagePool.sdp.carExplosionPool.GetPooledGameObject();
			explosion.SetActive(true);
			explosion.transform.position = structureParent.transform.position;
			SoundManager.sm.explosionSounds[i+1].Play();
		}
		gameObject.SetActive(false);
	}

	private void ResolveExplosion(float dmg) {
		Debug.Log($"in the func");
		Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, blastRadius);
		foreach(Collider2D col in colliderArray) {
			if (col.CompareTag("Enemy") || col.CompareTag("Player")) {
				Debug.Log($"col: {col.transform}");
				IHurtThingsInterface hit = col.GetComponent<IHurtThingsInterface>();
				hit.TakeDamage(dmg, "Fire");
				MMFloatingTextSpawnEvent.Trigger(0, col.attachedRigidbody.transform.position, 
					dmg.ToString(), Vector3.up, .5f);
			}
			
		}
	}
}
