using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BaseEnemy : MonoBehaviour, IDmgAndHpInterface {
	[Header("Enemy Stats")] public int maxHealth = 10;
	public int currentHealth = 10;
	public int damage = 1;
	public int moveSpeed = 5;
	public Rigidbody2D enemyRb2D;
	public Transform playerPosition;
	[Header("Spawn Mechanics")] public float spawnDistance;

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

	void OnTriggerStay2D(Collider2D other) {
		IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
		if (other.CompareTag("Enemy")) {
			hit.TakeDamage(damage);
		}
	}
	public void TakeDamage(int dmgAmount) {
		currentHealth -= dmgAmount;
		if (currentHealth <= 0) {
			Debug.Log("You have ceased to be!");
			// isDead == true;
			// play death animation
		}
	}
	// public void HealDamage(int healAmount) {
	// 	currentHealth += healAmount;
	// 	// play some animation of healing
	// 	if (currentHealth > maxHealth) {
	// 		currentHealth = maxHealth;
	// 	}
	// }
}

