using UnityEngine;
using UnityEngine.InputSystem;

public class Laser : MonoBehaviour {

	private LineRenderer _lineRenderer;
	public Transform playerCube;
	private float _laserRange = 4.5f;
	public GameObject laserHit;
	private LayerMask _hitMask;
	private Vector2 _fireLeft;
	private Vector2 _fireRight;
	void Start() {
		_fireLeft = new Vector2(-1f, -.15f);
		_fireRight = new Vector2(1f, -.15f);
		_lineRenderer = GetComponent<LineRenderer>();
		_hitMask = LayerMask.GetMask("Enemy");
	}
	private void Update() {
		FireLaserLogic();
	}

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

			IDmgAndHpInterface enemyHit = hit.collider.GetComponent<IDmgAndHpInterface>();
			if (hit.collider.CompareTag("Enemy")) {
				enemyHit.TakeDamage(0.05f);
			}
		} else {
			_lineRenderer.enabled = false;
		}

	}

	public void FireLaserLogic() {
		if (playerCube.transform.localScale.x < 0) {
			FireLaser(_fireLeft);
		}

		if (playerCube.transform.localScale.x > 0) {
			FireLaser(_fireRight);
		}
	}
}
