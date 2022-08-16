using UnityEngine;

public class TargetingSystem : MonoBehaviour {

	public Weapon weapon;
	public CircleCollider2D circleCol2D;
	public GameObject firePoint1, firePoint2, firePoint3, firePoint4;
	private float _sensorRange = 0f;

	private void Start() {
		_sensorRange = weapon.weaponRange;
	}

	private void Update() {
		ScanForTargets();
	}
	private void ScanForTargets() {
		Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, _sensorRange);
	    foreach (Collider2D col in colliderArray) {
	        if (col.TryGetComponent<BaseEnemy>(out BaseEnemy enemy)) {
        		weapon.AquireTarget(enemy);
	        }
	    }
	}
}