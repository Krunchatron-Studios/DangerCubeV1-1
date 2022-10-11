using System.Collections;
using Interfaces;
using Managers;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Feedbacks;

public class ShieldSystem : PlayerLogic {

	public CircleCollider2D shieldCollider;
	public Material shieldMaterial;
	public GameObject thisShield;
	public PlayerHealthAndShields healthAndShieldsData;
	public Slider slider;

	private void Start() {
		int id = Shader.PropertyToID("_GlitchFade");
		shieldMaterial.SetFloat(954, 0);

		slider.maxValue = healthAndShieldsData.playerShieldsMax;

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
		int id = Shader.PropertyToID("_GlitchFade");
		shieldMaterial.SetFloat(954, 1);
		yield return new WaitForSeconds(.25f);
		shieldMaterial.SetFloat(954, 0);
	}
	
	
	private void UpdateShieldBar() {
		slider.value = healthAndShieldsData.playerShieldsCurrent;
	}
}
