using UnityEngine;

public class AIBase : MonoBehaviour {

	public CircleCollider2D detectionCollider2D;
	public BaseEnemy enemy;
	public float distance;

	private void Start() {
		detectionCollider2D = GetComponent<CircleCollider2D>();
		detectionCollider2D.radius = enemy.lineOfSightDistance;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		GetDistance(other);
	}

	private void GetDistance(Collider2D other) {
		distance = Vector3.Distance(transform.position, other.transform.position);
		Debug.Log($"distance: {distance}");
	}
}
