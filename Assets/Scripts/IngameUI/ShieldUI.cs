using Interfaces;
using Managers;
using UnityEngine;

public class ShieldUI : PlayerLogic { 
	public ParticleSystem shieldParticle;
	public PlayerHealthAndShields healthAndShieldsData;

	public float shieldMaxRadius = 1.5f;
	public float remainingRadius;
	public float shieldShatterThreshold = 0.5f;
	public float shieldRechargeSpeed = .01f;
	private bool _shieldsShattered;
	private CircleCollider2D _circleCollider2D;

	[Header("Health Bar Vars")] 
	public HealthUI healthChunkHolder;
	
	[Header("Runtime Values")]
	[SerializeField] private float shieldConversion;
	[SerializeField] private float rawShieldRadius;
	private void Start() {
		_circleCollider2D = GetComponent<CircleCollider2D>();
		shieldParticle.transform.localScale = new Vector2(remainingRadius, remainingRadius);
		_circleCollider2D.radius = remainingRadius - .5f;
	}

	private void FixedUpdate() {
		
		UpdateShieldRadius();

		if (remainingRadius <= shieldShatterThreshold) {
			healthChunkHolder.RemoveHealthChunk();
			shieldParticle.transform.localScale = new Vector2(1, 1);
			healthAndShieldsData.playerShieldsCurrent = healthAndShieldsData.playerShieldsMax;
		}
	}

	private void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag("Projectile")) {
			IHurtThingsInterface hit = col.GetComponent<IHurtThingsInterface>();
			GameObject shield = EnemyPoolManager.epm.shieldHit.GetPooledGameObject();
			shield .SetActive(true);
			shield.transform.position = col.transform.position;
		}
	}

	private void UpdateShieldRadius() {
		shieldConversion = healthAndShieldsData.playerShieldsCurrent / healthAndShieldsData.playerShieldsMax;
		rawShieldRadius = shieldConversion + 0.15f;
		transform.localScale = new Vector2(rawShieldRadius, rawShieldRadius);
		remainingRadius = shieldConversion;
	}
}
