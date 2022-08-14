using UnityEngine;
public class BaseEnemy : MonoBehaviour
{
	[Header("Enemy Stats")]
	public int healthMax;
	public int currentHealth;
	public int damage;
	public int moveSpeed;
	
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

	private void MoveTowardsPlayer()
	{
		Vector3 temp = Vector3.MoveTowards(transform.position, playerPosition.position, moveSpeed * Time.deltaTime);
		enemyRb2D.MovePosition(temp);
	}
}
