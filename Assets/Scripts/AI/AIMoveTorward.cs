using UnityEngine;

namespace AI {
	public class AIMoveTorward : AIBase {

		private float _speed;
		public float stopDistance;
		private Transform _target;
		private Vector2 direction;
		public SpriteRenderer spriteRenderer;
		private static readonly int IsRunning = Animator.StringToHash("isRunning");

		private void Start() {
			_target = GameObject.FindObjectOfType<PlayerMovement>().GetComponent<Transform>();
			_speed = enemy.moveSpeed;
		}

		private void Update() {
			direction = (_target.position - transform.position).normalized;
			spriteRenderer.flipX = direction.x < 0;
		}

		private void LateUpdate() {
			
			Debug.Log($"flip: {GetComponent<SpriteRenderer>().flipX}");
			if (Vector2.Distance(transform.position, _target.position) > stopDistance) {
				transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
				enemy.animator.SetBool(IsRunning, true);
			}
		}
	}
}
