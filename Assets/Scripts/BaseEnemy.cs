using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
	[Header("Enemy Stats")]
	[SerializeField] private int _healthMax;
	private int _currentHealth;
	public int _damage;
	[SerializeField] private int _speed;
	[Header("Movement Dependencies")]
	[SerializeField] private Rigidbody2D _enemyRB;
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
		_enemyRB.MovePosition(temp);
	}

	private void DealDamage(int damageAmount)
	{
	}
}
