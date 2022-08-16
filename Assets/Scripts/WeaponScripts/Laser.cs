using UnityEngine;
using UnityEngine.InputSystem;

public class Laser : MonoBehaviour {

	private LineRenderer _lineRenderer;
	public Weapon weapon;
	void Start() {
		_lineRenderer = GetComponent<LineRenderer>();
	}
	private void Update() {
		//_lineRenderer.SetPosition(0, transform.position);
		RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
		
		if (hit.collider) {
			_lineRenderer.SetPosition(1, new Vector3(hit.point.x, hit.point.y, transform.position.z));
		} else {
			_lineRenderer.SetPosition(1, transform.up * 2000);
		}
	}
}
