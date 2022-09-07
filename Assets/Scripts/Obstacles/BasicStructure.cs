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

		GameObject dustPoof = PoolManager.pm.softDustPool.GetPooledGameObject();
		dustPoof.SetActive(true);
		dustPoof.transform.position = location;
		WindowShatter(location);
		
		float actualDamage = damageAmount - toughness;
		if (toughness >= damageAmount) {
			actualDamage = 0;
		} else {
			actualDamage = Mathf.FloorToInt(damageAmount - toughness);
		}
		MMFloatingTextSpawnEvent.Trigger(1, transform.position,
			actualDamage.ToString(), Vector3.up, .3f);
		currentIntegrity -= actualDamage;
		percentDestroyed = currentIntegrity / maxIntegrity;
		
		if (percentDestroyed > 0 && percentDestroyed < stage3Threshold && stage3Dmg) {
			spriteRenderer.sprite = stage3Dmg;
		}
		if (percentDestroyed > stage3Threshold && percentDestroyed < stage2Threshold && stage2Dmg) {
			spriteRenderer.sprite = stage2Dmg;
			structureParent.evacuateThreshold--;
		}
		if (percentDestroyed > stage2Threshold && percentDestroyed < stage1Threshold && stage1Dmg) {
			spriteRenderer.sprite = stage1Dmg;
			GameObject rockShatter = PoolManager.pm.rockShatterPool.GetPooledGameObject();
			rockShatter.SetActive(true);
			rockShatter.transform.position = location;
			structureParent.evacuateThreshold -= 2;
		}

		if (structureParent.evacuateThreshold <= 0 && !structureParent.hasEvacuated) {
			structureParent.EvacuateBuilding(structureParent.buildingSize);
		}
	}

	private void WindowShatter(Vector3 location) {
		if (structureType == "Window") {
			GameObject  glassShatter = PoolManager.pm.glassShatterPool.GetPooledGameObject();
			glassShatter.SetActive(true);
			glassShatter.transform.position = location;
		} else {
			GameObject rockShatter = PoolManager.pm.rockShatterPool.GetPooledGameObject();
			rockShatter.SetActive(true);
			rockShatter.transform.position = location;
		}
	}
}
