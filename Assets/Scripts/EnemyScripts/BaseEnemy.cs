using MoreMountains.Feedbacks;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IDmgAndHpInterface {
	[Header("Enemy Stats")] 
	public float maxHealth = 10f;
	public float currentHealth = 10f;
	public float damage = 1f;
	public float moveSpeed = 5f;
	public int experienceValue;
	public Rigidbody2D enemyRb2D;
	public Transform playerPosition;

	[Header("Flash Feedback")] 
	public MMF_Player hitFlashFeedback;
	
	[Header("Spawn Mechanics")] 
	public float spawnDistance;

	[Header("Enemy Drop")] 
	public GameObject drop;

	[Header("Player Manager")] 
	public PlayerResources playerResources;
	
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
		if (other.CompareTag("Player")) {
			hit.TakeDamage(damage);
		}
	}
	public void TakeDamage(float dmgAmount) {
		currentHealth -= dmgAmount;
		hitFlashFeedback?.PlayFeedbacks();
		
		if (currentHealth <= 0) {
			playerResources.experience += experienceValue;
			Instantiate(drop, transform.position, Quaternion.identity);
			Destroy(gameObject, .2f);
		}
		

	}
	public void HealDamage(int healAmount) {
		currentHealth += healAmount;
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
	}
}

