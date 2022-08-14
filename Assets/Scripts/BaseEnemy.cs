using UnityEngine;
public class BaseEnemy : MonoBehaviour, IDmgAndHpInterface
{
	[Header("Enemy Stats")]
	public int maxHealth = 100;
	public int currentHealth = 100;
	public int damage = 5;
	public int moveSpeed = 5;


	private void FixedUpdate() {
		ChasePlayer();
	}

	void OnTriggerEnter2D(Collider2D other) {

		IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
		if (other.CompareTag("Enemy")) {
			hit.TakeDamage(damage);
			Debug.Log("hit the player");
		}
	}
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
	}
}
