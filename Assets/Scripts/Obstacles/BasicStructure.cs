using Interfaces;
using UnityEngine;

public class BasicStructure : MonoBehaviour, ISmashThingsInterface {

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

	public void DamageStructure(float damageAmount, string damageType) {

		float actualDamage = damageAmount - toughness;
		if (toughness >= damageAmount) {
			actualDamage = 0;
		} else {
			actualDamage = Mathf.FloorToInt(damageAmount - toughness);
		}
		currentIntegrity -= actualDamage;
		percentDestroyed = currentIntegrity / maxIntegrity;
		Debug.Log($"percent destroyed: {percentDestroyed}");
		if (percentDestroyed > 0 && percentDestroyed < stage3Threshold && stage3Dmg) {
			spriteRenderer.sprite = stage3Dmg;
			Debug.Log($"stage 3: {stage3Dmg}");

		}
		if (percentDestroyed > stage3Threshold && percentDestroyed < stage2Threshold && stage2Dmg) {
			spriteRenderer.sprite = stage2Dmg;
			Debug.Log($"stage 2: {stage2Dmg}");

		}
		if (percentDestroyed > stage2Threshold && percentDestroyed < stage1Threshold && stage1Dmg) {
			spriteRenderer.sprite = stage1Dmg;
			Debug.Log($"stage 1: {stage1Dmg}");

		}

		if (currentIntegrity <= 0) {
			// we destroy the object
		}
	}
	
	
}
