using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShieldUI : MonoBehaviour {
	public ParticleSystem shieldParticle;
	public PlayerHealthAndShields healthAndShieldsData;

	public float shieldMaxRadius = 1.5f;
	public float remainingRadius;
	public float shieldBaseBubbleSize = 0.5f;
	public float shieldRechargeSpeed = .01f;
	public float shieldOpacity = 0f;
	public float flickerStrength;
	private bool _shieldsShattered;

	[Header("Health Bar Vars")] 
	public GameObject[] healthChunkHolder;
	public GameObject healthChunk;
	
	[Header("Runtime Values")]
	[SerializeField] private float shieldConversion;
	[SerializeField] private float rawShieldRadius;
	[SerializeField] private float actualShieldRadius;
	private void Start() {
		InitializeHealthAndShields();
	}

	private void Update() {
		
		UpdateShieldRadius();
		if (remainingRadius <= shieldBaseBubbleSize) {
			_shieldsShattered = true;
			healthAndShieldsData.playerHealthCurrent--;
		}
	}

	private void UpdateShieldRadius() {
		shieldConversion = (healthAndShieldsData.playerShieldsCurrent / healthAndShieldsData.playerShieldsMax) * .5f;
		rawShieldRadius = shieldConversion + shieldBaseBubbleSize;
		transform.localScale = new Vector2(rawShieldRadius, rawShieldRadius);
	}

	private void ShieldFlicker() {
		if (CompareTag("Enemy") || CompareTag("Projectile")) {
		}
	}

	private void InitializeHealthAndShields() {
		shieldParticle.transform.localScale = new Vector2(remainingRadius, remainingRadius);
		for (int i = 0; i < healthAndShieldsData.playerHealthMax; i++) {
			healthChunkHolder[i] = healthChunk;
		}
	}
}
