using Managers;
using UnityEngine;

namespace AI {
	public class AIMoveTorward : AIBase {

		private float _speed;
		public float stopDistance = 4f;
		public float fleeDistance = 2f;
		private Transform _target;
		private Vector2 _direction;
		private static readonly int IsRunning = Animator.StringToHash("isRunning");

		private void Start() {
			_speed = enemy.moveSpeed;
		}

		private void Update() {
			_target = GameObject.FindObjectOfType<PlayerMovement>().GetComponent<Transform>();
			distance = Vector3.Distance(transform.position, _target.position);
			_direction = (_target.position - transform.position).normalized;
			spriteRenderer.flipX = _direction.x < 0;
			if (distance < 10.0f) {
				hasEngaged = true;
			}
		}

		private void LateUpdate() {

			if (hasEngaged) {
				if (Vector2.Distance(transform.position, _target.position) > stopDistance) {
					transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
					enemy.animator.SetBool(IsRunning, true);enemy.animator.SetBool(IsRunning, true);
				}
			
				if(Vector2.Distance(transform.position, _target.position) < fleeDistance) {
					transform.position = Vector2.MoveTowards(transform.position, _target.position, -_speed * Time.deltaTime);
					enemy.animator.SetBool(IsRunning, true);
				}
			}
		}
	}
}
