using System;
using UnityEngine;

public class TargetingSystem : MonoBehaviour {

	public Weapon weapon;
	public CircleCollider2D circleCol2D;
	public GameObject firePoint1, firePoint2, firePoint3, firePoint4;
	private float _sensorRange = 0f;

	private void Start() {
		_sensorRange = weapon.weaponRange;
		Debug.Log(_sensorRange + "sensor range");
	}

	private void Update() {
		Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, _sensorRange);
		foreach (Collider2D collider2D in colliderArray) {
			if (collider2D.TryGetComponent<BaseEnemy>(out BaseEnemy enemy)) {
				weapon.AquireTarget(enemy);
				Debug.Log(enemy);
			}
		}
	}

	private void ScanForTargets() {
		Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, _sensorRange);
	    foreach (Collider2D col in colliderArray) {
	        if (col.TryGetComponent<BaseEnemy>(out BaseEnemy enemy)) {
        		weapon.AquireTarget(enemy);
        		Debug.Log(enemy);
	        }
	    }
	}
}
