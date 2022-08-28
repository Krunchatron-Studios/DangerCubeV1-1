using UnityEngine;

public class ShieldUI : MonoBehaviour { 
	public ParticleSystem shieldParticle;
	public PlayerHealthAndShields healthAndShieldsData;

	public float shieldMaxRadius = 1.5f;
	public float remainingRadius;
	public float shieldShatterThreshold = 0.5f;
	public float shieldRechargeSpeed = .01f;
	public float shieldOpacity = 0f;
	public float flickerStrength;
	private bool _shieldsShattered;

	[Header("Health Bar Vars")] 
	public HealthUI healthChunkHolder;
	
	[Header("Runtime Values")]
	[SerializeField] private float shieldConversion;
	[SerializeField] private float rawShieldRadius;
	private void Start() {
		shieldParticle.transform.localScale = new Vector2(remainingRadius, remainingRadius);
	}

	private void Update() {
		
		UpdateShieldRadius();
		if (remainingRadius <= shieldShatterThreshold) { 
			healthChunkHolder.UpdateHealthChunks();
		}
	}

	private void UpdateShieldRadius() {
		shieldConversion = healthAndShieldsData.playerShieldsCurrent / healthAndShieldsData.playerShieldsMax;
		rawShieldRadius = shieldConversion + 0.15f;
		transform.localScale = new Vector2(rawShieldRadius, rawShieldRadius);
		remainingRadius = shieldConversion;
	}

	private void ShieldFlicker() {
		if (CompareTag("Enemy") || CompareTag("Projectile")) {
		}
	}
}
