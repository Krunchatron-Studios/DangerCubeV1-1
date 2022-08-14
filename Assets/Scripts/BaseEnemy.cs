using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
	[Header("Enemy Stats")]
	[SerializeField] private int _health;
	[SerializeField] private int _speed;
	private Rigidbody2D _enemyRB;
	
}
