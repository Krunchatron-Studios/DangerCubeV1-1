using UnityEngine;

public class BaseEnemy : MonoBehaviour, IDmgAndHpInterface {
	[Header("Enemy Stats")] 
	public int maxHealth = 10;
	public int currentHealth = 10;
	public int damage = 1;
	public int moveSpeed = 5;
	public Rigidbody2D enemyRb2D;
	public Transform playerPosition;
	
	[Header("Spawn Mechanics")] 
	public float spawnDistance;

	[Header("Enemy Drop")] 
	public GameObject drop;

	void Start() {
		playerPosition = GameObject.FindWithTag("Player").transform;
	}
	void FixedUpdate() {
		MoveTowardsPlayer();
	}

	public virtual void MoveTowardsPlayer() {
		Vector3 temp = Vector3.MoveTowards(transform.position, playerPosition.position, moveSpeed * Time.deltaTime);
		enemyRb2D.MovePosition(temp);
	}
	void OnTriggerEnter2D(Collider2D other) {
		IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
		if (other.CompareTag("Projectile")) {
			hit.TakeDamage(damage);
		}
	}
	public virtual void TakeDamage(int dmgAmount) {
		currentHealth -= dmgAmount;
		if (currentHealth <= 0) {
			// isDead == true;
			// play death animation
			Instantiate(drop, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
	public void HealDamage(int healAmount) {
		currentHealth += healAmount;
		// play some animation of healing
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
	}
}

