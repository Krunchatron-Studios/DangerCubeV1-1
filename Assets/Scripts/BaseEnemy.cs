using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
	[Header("Enemy Stats")]
<<<<<<< HEAD
	public int maxHealth;
	public int currentHealth;
	public int damage;
	public int moveSpeed;
=======
	[SerializeField] private int _healthMax;
	private int _currentHealth;
	public int _damage;
	public int _speed;
	[Header("Movement Dependencies")]
	public Rigidbody2D _enemyRB;
	public Transform _playerPosition;
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
	
>>>>>>> b64ef155209b6c4e2462349b5158b11d9941ff7f
	
	[Header("Movement Dependencies")]
	public Rigidbody2D enemyRb2D;
	public Transform playerPosition;
	
	void Start()
	{
		playerPosition = GameObject.FindWithTag("Player").transform;
	}
	void FixedUpdate()
	{
		MoveTowardsPlayer();
	}

	public void MoveTowardsPlayer()
	{
		Vector3 temp = Vector3.MoveTowards(transform.position, playerPosition.position, moveSpeed * Time.deltaTime);
		enemyRb2D.MovePosition(temp);
	}
}