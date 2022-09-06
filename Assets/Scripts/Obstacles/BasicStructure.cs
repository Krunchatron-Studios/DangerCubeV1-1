using System;
using UnityEngine;

public class BasicStructure : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public Sprite noDmgSprite;
	public Sprite stage1Dmg;
	public Sprite stage2Dmg;
	public Sprite stage3Dmg;

	public float toughness;
	public float maxIntegrity;
	public float currentIntegrity;
	public float percentDestroyed;

	private void Start() {
		spriteRenderer.sprite = noDmgSprite;
	}

	public void DamageStructure(float damageAmount, string damageType) {

		float actualDamage = damageAmount - toughness;
		currentIntegrity -= actualDamage;
		percentDestroyed = currentIntegrity / maxIntegrity;
		
		
	}
	
	
}
