using Interfaces;
using MoreMountains.Tools;
using UnityEngine;

public class DeathRayBeam : MonoBehaviour {

	public DeathRay deathRay;
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Enemy")) {
			MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position,
				deathRay.weaponDamage.ToString(), Vector3.up, .2f);
			IHurtThingsInterface hit = other.GetComponent<IHurtThingsInterface>();
			hit.TakeDamage(deathRay.weaponDamage, "DeathRay");
		}

		if (other.CompareTag("Obstacle")) {
			Debug.Log($"other: {other.name}");
			ISmashThingsInterface hit = other.GetComponent<ISmashThingsInterface>();
			hit.DamageStructure(deathRay.weaponDamage, "DeathRay", other.transform.position);
		}
	}
}
