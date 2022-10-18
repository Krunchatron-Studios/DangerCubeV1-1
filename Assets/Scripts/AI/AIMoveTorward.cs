using UnityEngine;

namespace AI {
	public class AIMoveTorward : AIBase {

		private float _speed;
		public float stopDistance = 4f;
		public float fleeDistance = 2f;
		private Vector3 _target;
		private Vector2 _direction;

		private void Start() {
			_speed = enemy.moveSpeed;
			_target = GameObject.FindWithTag("Player").transform.position;
		}
		private void LateUpdate() {

			// spriteRenderer.flipX = -_direction.x < 0;
			if (hasEngaged) {
				_target = GameObject.FindWithTag("Player").transform.position;
				if (Vector2.Distance(transform.position, _target) > stopDistance) {
					transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
					enemy.animator.SetBool("IsRunning", true);
				}
			
				if(Vector2.Distance(transform.position, _target) < fleeDistance) {
					transform.position = Vector2.MoveTowards(transform.position, _target, -_speed * Time.deltaTime);
					enemy.animator.SetBool("IsRunning", true);
				}
			}
		}
	}
}
