using System.Collections;
using Effects;
using Interfaces;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

public class BaseEnemy : MonoBehaviour, IHurtThingsInterface {

	public string enemyName;
	[Header("Enemy Stats")] 
	public float maxHealth = 3f;
	public float currentHealth = 3f;
	public float damage = 1f;
	public float moveSpeed = 2f;
	public float lineOfSightDistance = 5f;
	public Rigidbody2D enemyRb2D;
	public Animator animator;
	public EnemyWeapon weapon;
	public SpriteRenderer spriteRenderer;
	
	[Header("Death Effects")] 
	public Dissolve dissolve;

	public HitEffects hitEffects;
	
	[Header("Enemy Drop Related")] 
	public GameObject drop;
	public PlayerResources playerResources;
	private Vector2 _direction;

	public void TakeDamage(float dmgAmount, string dmgType) {
		currentHealth -= dmgAmount;
		
		if (dmgType == "Physical") {
			_direction = GameObject.FindGameObjectWithTag("Player").transform.localScale.normalized;
			GameObject blood = PoolManager.pm.bloodPool.GetPooledGameObject();
			blood.transform.position = new Vector2(transform.position.x, transform.position.y + .5f);
			blood.transform.localScale = new Vector3(-_direction.x, _direction.y, 0);
			blood.SetActive(true);
			Debug.Log($"lossy: {_direction}");
		}
		
		if (currentHealth <= 0) {
			if (dmgType == "DeathRay") {
				spriteRenderer.material = ShaderManager.shm.dissolve;
				GameObject ashes = PoolManager.pm.ashesPool.GetPooledGameObject();
				ashes.SetActive(true);
				ashes.transform.position = transform.position;
				dissolve.isDissolving = true;
			}

			if (dmgType != "Physical") {
				GameObject blood = PoolManager.pm.bloodPool.GetPooledGameObject();
				blood.transform.position = transform.position;
				blood.SetActive(true);
			}
			
			moveSpeed = 0f;
			Instantiate(drop, transform.position, Quaternion.identity);
			StartCoroutine(PostponeDeath(1f));
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
	IEnumerator PostponeDeath(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		gameObject.SetActive(false);
	}
}

