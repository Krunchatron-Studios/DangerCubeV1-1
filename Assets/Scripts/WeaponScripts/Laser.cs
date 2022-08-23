using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.InputSystem;

public class Laser : MonoBehaviour {

	private LineRenderer _lineRenderer;
	public Transform playerCube;
	private readonly float _laserRange = 3.5f;
	public float laserDamage = .05f;
	public GameObject laserHitMarker;
	private LayerMask _whatGetsHitMask;
	private Vector2 _direction;

	void Start() {
		_direction = new Vector2(1f, -.15f);
		_lineRenderer = GetComponent<LineRenderer>();
		_whatGetsHitMask = LayerMask.GetMask("Enemy");
	}
	private void Update() {
		_direction.x = playerCube.transform.localScale.x;
		FireLaser(_direction);
	}

	public void FireLaser(Vector2 dir) {
		
		if (Keyboard.current.spaceKey.isPressed || Gamepad.current.bButton.isPressed) {
			_lineRenderer.enabled = true;

			var position = transform.position;
			RaycastHit2D hit = Physics2D.Raycast(position, dir, _laserRange, _whatGetsHitMask);
			_lineRenderer.SetPosition(0, position);
			
			if (hit && hit.distance < _laserRange) {
				_lineRenderer.SetPosition(1, hit.point);

			} else {
				_lineRenderer.SetPosition(1, laserHitMarker.transform.position);
			}
			
			if (hit) {
				if (hit.transform.CompareTag("Enemy")) {
					IDmgAndHpInterface enemyHit = hit.collider.GetComponent<IDmgAndHpInterface>();
					enemyHit.TakeDamage(0.05f);
					MMFloatingTextSpawnEvent.Trigger(0, hit.point, laserDamage.ToString(), Vector3.up, .5f);
				}
			}
		} else {
			_lineRenderer.enabled = false;
		}

	}
	
}
