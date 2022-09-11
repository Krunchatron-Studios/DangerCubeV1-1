using Interfaces;
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
	public float stage1Threshold = .9f;
	public float stage2Threshold = .6f;
	public float stage3Threshold = .3f;

	public float toughness;
	public float maxIntegrity;
	public float currentIntegrity;
	public float percentDestroyed;
	

	private void Start() {
		spriteRenderer.sprite = noDmgSprite;
	}

	public void DamageStructure(float damageAmount, string damageType, Vector3 location) {
		shaker.Play();
		GetDustParticle(location);
		WindowShatterCheck(location);
		CalculateDamage(damageAmount);
		DamageTiersCheck(location);
		percentDestroyed = currentIntegrity / maxIntegrity;
		CatchFire(damageType);
		EvacuateCheck();
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
	private void DamageTiersCheck(Vector3 location) {
		if (percentDestroyed > 0 && percentDestroyed < stage3Threshold && stage3Dmg) {
			spriteRenderer.sprite = stage3Dmg;
		}
		if (percentDestroyed > stage3Threshold && percentDestroyed < stage2Threshold && stage2Dmg) {
			spriteRenderer.sprite = stage2Dmg;
			structureParent.evacuateThreshold--;
		}
		if (percentDestroyed > stage2Threshold && percentDestroyed < stage1Threshold && stage1Dmg) {
			spriteRenderer.sprite = stage1Dmg;
			GameObject rockShatter = StructureDamagePool.sdp.rockShatterPool.GetPooledGameObject();
			rockShatter.SetActive(true);
			rockShatter.transform.position = location;
			structureParent.evacuateThreshold -= 2;
		}
	}
	private void GetDustParticle(Vector3 location) {
		GameObject dustPoof = StructureDamagePool.sdp.softDustPool.GetPooledGameObject();
		dustPoof.SetActive(true);
		dustPoof.transform.position = location;
	}
	private void CalculateDamage(float damageAmount) {
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
	private void CatchFire(string damageType) {
		if (damageType == "Fire" || damageType == "DeathRay") {

			if (percentDestroyed < 0.9f) {
				structureParent.fireAndSmokeDamageArray[0].SetActive(true);
			}

			if (percentDestroyed < 0.7f) {
				structureParent.fireAndSmokeDamageArray[1].SetActive(true);
			}

			if (percentDestroyed < 0.5f) {
				structureParent.fireAndSmokeDamageArray[2].SetActive(true);

				if (structureType != "Vehicle") {
					SoundManager.sm.burning1.Play();
				}
			}

			if (percentDestroyed < 0.3f) {
				structureParent.fireAndSmokeDamageArray[3].SetActive(true);
			}
			
		}
	}
}
