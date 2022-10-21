using System.Collections;
using Interfaces;
using Managers;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Feedbacks;

public class ShieldSystem : PlayerLogic {

	public CircleCollider2D shieldCollider;
	public HealthUI healthUI;
	public Material shieldMaterial;
	public GameObject thisShield;
	public Slider slider;

	private void Start() {
		int id = Shader.PropertyToID("_GlitchFade");
		shieldMaterial.SetFloat(id, 0);
		slider.maxValue = healthAndShields.playerShieldsMax;
	}

	private void FixedUpdate() {
		UpdateShieldBar();
	}
	
	private void OnTriggerEnter2D(Collider2D col) {
		if (col.CompareTag("EnemyProjectile")) {
			IHurtThingsInterface hit = col.GetComponent<IHurtThingsInterface>();
			GameObject shield = EnemyPoolManager.epm.shieldHit.GetPooledGameObject();
			shield .SetActive(true);
			shield.transform.position = col.transform.position;
			MMCameraShakeEvent.Trigger(.1f, .2f, 40f, 0, 0, 0, false);
			StartCoroutine(ShieldHitEffect());
		}
	}

	IEnumerator ShieldHitEffect() {
		int idGlitchFade = Shader.PropertyToID("_GlitchFade");
		int idSineGlow = Shader.PropertyToID("_SineGlowFade");
		shieldMaterial.SetFloat(idGlitchFade, 1);
		shieldMaterial.SetFloat(idSineGlow, 1);
		yield return new WaitForSeconds(.25f);
		shieldMaterial.SetFloat(idGlitchFade, 0);
		shieldMaterial.SetFloat(idSineGlow, 0);
	}
	
	
	private void UpdateShieldBar() {
		slider.value = healthAndShields.playerShieldsCurrent;
		if (healthAndShields.playerShieldsCurrent <= 0) {
			healthUI.RemoveHealthChunk();
			healthAndShields.playerShieldsCurrent = healthAndShields.playerShieldsMax;
		}
	}
}
