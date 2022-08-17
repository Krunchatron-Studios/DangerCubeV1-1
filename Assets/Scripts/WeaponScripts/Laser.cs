using UnityEngine;
using UnityEngine.InputSystem;

public class Laser : MonoBehaviour {

	private LineRenderer _lineRenderer;
	public Transform playerCube;
	private float _laserRange = 3.5f;
	public GameObject laserHit;
	private LayerMask _hitMask;
	private Vector2 direction;

	void Start() {
		direction = new Vector2(1f, -.15f);
		_lineRenderer = GetComponent<LineRenderer>();
		_hitMask = LayerMask.GetMask("Enemy");
	}
	private void Update() {
		direction.x = playerCube.transform.localScale.x;
		FireLaser(direction);
	}

	// ReSharper disable Unity.PerformanceAnalysis
	public void FireLaser(Vector2 dir) {
		
		if (Keyboard.current.spaceKey.isPressed) {
			_lineRenderer.enabled = true;

			RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, _laserRange, _hitMask);

			_lineRenderer.SetPosition(0, transform.position);
			if (hit && hit.distance < _laserRange) {
				_lineRenderer.SetPosition(1, hit.point);
			} else {
				_lineRenderer.SetPosition(1, laserHit.transform.position);
			}
			
			if (hit.collider.CompareTag("Enemy")) {
				IDmgAndHpInterface enemyHit = hit.collider.GetComponent<IDmgAndHpInterface>();
				enemyHit.TakeDamage(0.05f);
			}
		} else {
			_lineRenderer.enabled = false;
		}

	}
	
}
