using UnityEngine;

public class BaseEnemy : MonoBehaviour, IDmgAndHpInterface {
	[Header("Enemy Stats")] 
	public int maxHealth = 10;
	public int currentHealth = 10;
	public int damage = 1;
	public int moveSpeed = 5;
	public int experienceValue;
	public Rigidbody2D enemyRb2D;
	public Transform playerPosition;
	
	[Header("Spawn Mechanics")] 
	public float spawnDistance;

	[Header("Enemy Drop")] 
	public GameObject drop;

	[Header("Player Manager")] 
	public PlayerResources playerResources;

	public PlayerHealthAndShields healthAndShields;

	void Start() {
		playerPosition = GameObject.FindWithTag("Player").transform;
	}
	void FixedUpdate() {
		MoveTowardsPlayer();
	}
// testing
	public virtual void MoveTowardsPlayer() {
		Vector3 temp = Vector3.MoveTowards(transform.position, playerPosition.position, moveSpeed * Time.deltaTime);
		enemyRb2D.MovePosition(temp);
	}
	void OnTriggerEnter2D(Collider2D other) {
		IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
		if (other.CompareTag("Projectile")) {
			hit.TakeDamage(damage);
		} else if (other.CompareTag("Player")) {
			DealDamage(damage);
		}
	}
	public void TakeDamage(int dmgAmount) {
		currentHealth -= dmgAmount;
		if (currentHealth <= 0) {
			playerResources.experience += experienceValue;
			// isDead == true;
			// play death animation
			Instantiate(drop, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
	public void DealDamage(int damageAmount) {
		Debug.Log("In the damage dealer");
		if (healthAndShields.playerShieldsCurrent > 0) {
			healthAndShields.playerShieldsCurrent -= damageAmount;
		} else if (healthAndShields.playerHealthCurrent > 0) {
			healthAndShields.playerHealthCurrent -= damageAmount;
		} else if (healthAndShields.playerHealthCurrent <= 0) {
			//change reference to player object
			// Destroy(this.gameObject);
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

