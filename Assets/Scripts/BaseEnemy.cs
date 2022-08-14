using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
	[Header("Enemy Stats")]
	[SerializeField] private int _health;
	[SerializeField] private int _speed;
	public Transform _playerPosition;

	void Start()
	{
		_playerPosition = GameObject.FindWithTag("Player").transform;
	}

	void FixedUpdate()
	{
		MoveTowardsPlayer();
	}

	private void MoveTowardsPlayer()
	{
		Vector3 temp = Vector3.MoveTowards(transform.position, _playerPosition.position, _speed * Time.deltaTime);
	}
}
