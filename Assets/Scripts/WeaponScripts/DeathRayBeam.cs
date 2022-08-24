using MoreMountains.Tools;
using UnityEngine;

public class DeathRayBeam : MonoBehaviour {

	public float beamDamage = .10f;
	private void OnTriggerStay2D(Collider2D other) {
		if (other.CompareTag("Enemy")) {
			MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position,
				beamDamage.ToString(), Vector3.up, .2f);
			IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
			hit.TakeDamage(beamDamage);
		}
		
	}
}
