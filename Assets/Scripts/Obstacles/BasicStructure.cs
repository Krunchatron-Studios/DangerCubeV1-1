using Interfaces;
using Managers;
using MoreMountains.Feedbacks;
using UnityEngine;
using MoreMountains.Tools;

public class BasicStructure : MonoBehaviour, ISmashThingsInterface {

	public CombinedStructure structureParent;
	public string structureType;
	public MMPositionShaker shaker;
	public SpriteRenderer spriteRenderer;
	public Sprite noDmgSprite;
	public Sprite stage1Dmg;
	public Sprite stage2Dmg;
	public Sprite stage3Dmg;
	public bool stage1Crumble, stage2Crumble;
	public float stage1Threshold = .9f;
	public float stage2Threshold = .6f;
	public float stage3Threshold = .3f;

	public float toughness;
	public float maxIntegrity;
	public float currentIntegrity;
	public float percentDestroyed;
	private bool _looted;
	

	private void Start() {
		_looted = false;
		spriteRenderer.sprite = noDmgSprite;
	}

	public virtual void DamageStructure(float damageAmount, string damageType, Vector3 location) {
		shaker.Play();
		GetDustParticle(location);
		WindowShatterCheck(location);
		CalculateDamage(damageAmount);
		DamageTiersCheck1(location);
		DamageTiersCheck2(location);
		DamageTiersCheck3(location);
		percentDestroyed = currentIntegrity / maxIntegrity;
		CatchFire(damageType);
		EvacuateCheck();
		FinalCrumble();
	}
	private void WindowShatterCheck(Vector3 location) {
		if (structureType == "Window") {
			GameObject  glassShatter = StructureDamagePool.sdp.glassShatterPool.GetPooledGameObject();
			glassShatter.SetActive(true);
			glassShatter.transform.position = location;
		} else {
			GameObject rockShatter = StructureDamagePool.sdp.rockShatterPool.GetPooledGameObject();
			rockShatter.SetActive(true);
			rockShatter.transform.position = location;
		}
	}
	public virtual void GetDustParticle(Vector3 location) {
		GameObject dustPoof = StructureDamagePool.sdp.softDustPool.GetPooledGameObject();
		dustPoof.SetActive(true);
		dustPoof.transform.position = location;
	}
	public void CalculateDamage(float damageAmount) {
		float actualDamage = damageAmount - toughness;
		if (toughness >= damageAmount) {
			actualDamage = 0;
		} else {
			actualDamage = Mathf.FloorToInt(damageAmount - toughness);
		}
		MMFloatingTextSpawnEvent.Trigger(1, transform.position,
			actualDamage.ToString(), Vector3.up, .3f);
		currentIntegrity -= actualDamage;
	}
	private void EvacuateCheck() {
		if (structureParent.evacuateThreshold <= 0 && !structureParent.hasEvacuated) {
			structureParent.EvacuateBuilding(structureParent.buildingSize);
		}
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

			if (currentIntegrity <= 0.0f) {
				SoundManager.sm.burning1.Stop();
			}
		}
	}
	public virtual void DamageTiersCheck1(Vector3 location) {
		if (percentDestroyed < stage1Threshold && stage1Dmg) {
			spriteRenderer.sprite = stage1Dmg;
			GameObject rockShatter = StructureDamagePool.sdp.rockShatterPool.GetPooledGameObject();
			rockShatter.SetActive(true);
			rockShatter.transform.position = location;
			structureParent.evacuateThreshold--;
		}
	}
	public virtual void DamageTiersCheck2(Vector3 location) {
		if (percentDestroyed < stage2Threshold && stage2Dmg) {
			spriteRenderer.sprite = stage2Dmg;
			structureParent.evacuateThreshold--;
		}
	}
	public virtual void DamageTiersCheck3(Vector3 location) {
		if (percentDestroyed < stage3Threshold && stage3Dmg) {
			spriteRenderer.sprite = stage3Dmg;

			if (structureType == "Building" && !_looted) {
				GameObject buildingLoot = PoolManager.pm.sSilicatePool.GetPooledGameObject();
				buildingLoot.SetActive(true);
				buildingLoot.transform.position = location;
				_looted = true;
			}
		}
	}
	public virtual void FinalCrumble() {
		if (currentIntegrity <= 0.0f && !structureParent.stage2Crumble) {
			SoundManager.sm.buildingCrumbleSounds[0].Play();
			stage2Crumble = true;
		}
	}
}
