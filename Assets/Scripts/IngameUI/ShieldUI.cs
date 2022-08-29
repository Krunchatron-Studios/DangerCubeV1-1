using UnityEngine;

public class ShieldUI : MonoBehaviour { 
	public ParticleSystem shieldParticle;
	public PlayerHealthAndShields healthAndShieldsData;

	public float shieldMaxRadius = 1.5f;
	public float remainingRadius;
	public float shieldShatterThreshold = 0.5f;
	public float shieldRechargeSpeed = .01f;
	private bool _shieldsShattered;

	[Header("Health Bar Vars")] 
	public HealthUI healthChunkHolder;
	
	[Header("Runtime Values")]
	[SerializeField] private float shieldConversion;
	[SerializeField] private float rawShieldRadius;
	private void Start() {
		shieldParticle.transform.localScale = new Vector2(remainingRadius, remainingRadius);
	}

	private void FixedUpdate() {
		
		UpdateShieldRadius();

		if (remainingRadius <= shieldShatterThreshold) {
			healthChunkHolder.RemoveHealthChunk();
			shieldParticle.transform.localScale = new Vector2(1, 1);
			healthAndShieldsData.playerShieldsCurrent = healthAndShieldsData.playerShieldsMax;
		}
	}

	private void UpdateShieldRadius() {
		shieldConversion = healthAndShieldsData.playerShieldsCurrent / healthAndShieldsData.playerShieldsMax;
		rawShieldRadius = shieldConversion + 0.15f;
		transform.localScale = new Vector2(rawShieldRadius, rawShieldRadius);
		remainingRadius = shieldConversion;
	}
}
