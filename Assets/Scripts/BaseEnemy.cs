using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
	[Header("Enemy Stats")]
	[SerializeField] private int _healthMax;
	private int _currentHealth;
	public int _damage;
	public int _speed;
	[Header("Movement Dependencies")]
	public Rigidbody2D _enemyRB;
	public Transform _playerPosition;
	[Header("Spawn Mechanics")] public float _spawnDistance;
	void Start()
	{
		_playerPosition = GameObject.FindWithTag("Player").transform;
	}
	void FixedUpdate()
	{
		MoveTowardsPlayer();
	}

	public virtual void MoveTowardsPlayer()
	{
		Vector3 temp = Vector3.MoveTowards(transform.position, _playerPosition.position, _speed * Time.deltaTime);
		_enemyRB.MovePosition(temp);
	}
	
	
}
