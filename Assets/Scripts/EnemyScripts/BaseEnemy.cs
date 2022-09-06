using Interfaces;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IHurtThingsInterface {

	[Header("Enemy Stats")] 
	public float maxHealth = 10f;
	public float currentHealth = 10f;
	public float damage = 1f;
	public float moveSpeed = 5f;
	public Rigidbody2D enemyRb2D;
	public Transform playerPosition;

	[Header("Dissolve Class")] 
	public Dissolve dissolve;

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
		IHurtThingsInterface hit = other.GetComponent<IHurtThingsInterface>();
		if (other.CompareTag("Player")) {
			hit.TakeDamage(damage, "Physical");
		}
	}
	public void TakeDamage(float dmgAmount, string dmgType) {
		currentHealth -= dmgAmount;
		if (currentHealth <= 0) {

			if (dmgType == "DeathRay") {
				GameObject ashes = PoolManager.pm.ashesPool.GetPooledGameObject();
				dissolve.isDissolving = true;
				ashes.transform.position = transform.position;
				ashes.SetActive(true);
			}

			if (dmgType != "Physical") {
				GameObject blood = PoolManager.pm.bloodPool.GetPooledGameObject();
				dissolve.isDissolving = true;
				blood.transform.position = transform.position;
				blood.SetActive(true);
			}
			
			moveSpeed = 0f;
			Instantiate(drop, transform.position, Quaternion.identity);
			// Needs pooling but may require reworking some things
			gameObject.SetActive(false);
			int deathSoundIndex = Random.Range(0, 3);
			SoundManager.sm.humanDying[deathSoundIndex].Play();
		}
	}
	public void HealDamage(int healAmount) {
		currentHealth += healAmount;
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
	}
}

