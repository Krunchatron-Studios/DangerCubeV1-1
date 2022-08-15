using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
	[Header("Enemy Stats")]
<<<<<<< HEAD
	public int maxHealth = 10;
	public int currentHealth = 10;
	public int damage = 1;
	public int moveSpeed = 5;

=======
<<<<<<< HEAD
<<<<<<< HEAD
	public int maxHealth = 100;
	public int currentHealth = 100;
	public int damage = 5;
	public int moveSpeed = 5;


	private void FixedUpdate() {
		ChasePlayer();
=======
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
>>>>>>> master
	public Rigidbody2D enemyRb2D;
	public Transform playerPosition;
	void Start() {
		playerPosition = GameObject.FindWithTag("Player").transform;
	}
	void Update() {
		MoveTowardsPlayer();
>>>>>>> Tdev
	}
	public void MoveTowardsPlayer()
	{
		Vector3 temp = Vector3.MoveTowards(transform.position, playerPosition.position, moveSpeed * Time.deltaTime);
		enemyRb2D.MovePosition(temp);
	}
<<<<<<< HEAD
	private void ChasePlayer() {
		
	}

	public void TakeDamage(int dmgAmount) {
		currentHealth -= dmgAmount;
		if (currentHealth <= 0) {
			// isDead == true;
			// play death animation
		}
	}

	public void HealDamage(int healAmount) {
		currentHealth += healAmount;
		// play some animation of healing
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
=======
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
>>>>>>> 019f8cba37445c27b698586d09f447d62d480454
	}
}
=======
}
>>>>>>> Tdev
