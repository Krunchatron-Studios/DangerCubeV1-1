using System;
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
	
	[Header("Enemy Drop Related")] 
	public GameObject drop;
	public PlayerResources playerResources;
	private Vector2 _direction;

	[Header("Player Target")] 
	public GameObject _playerObject;

	private void LateUpdate() {
		_playerObject = GameObject.FindWithTag("Player");
		_direction = (_playerObject.transform.position - transform.position).normalized;
		FlipEnemySprite();
	}

	public void TakeDamage(float dmgAmount, string dmgType) {
		currentHealth -= dmgAmount;
		
		// hit effects from weapons
		if (dmgType == "Physical") {
			_direction = GameObject.FindGameObjectWithTag("Player").transform.localScale.normalized;
			GameObject blood = PoolManager.pm.bloodPool.GetPooledGameObject();
			blood.transform.position = new Vector2(transform.position.x, transform.position.y + .5f);
			blood.transform.localScale = new Vector3(-_direction.x, _direction.y, 0);
			blood.SetActive(true);
		}

		if (dmgType == "Fire") {
			GameObject fire = PoolManager.pm.firePool.GetPooledGameObject();
			fire.SetActive(true);
			fire.transform.position = transform.position;
		}
		
		if (dmgType == "Plasma") {
			GameObject plasma = PoolManager.pm.plasmaPool.GetPooledGameObject();
			plasma.SetActive(true);
			plasma.transform.position = transform.position;
		}
		
		// Death effects from weapons
		if (currentHealth <= 0) {
			if (dmgType == "DeathRay") {
				spriteRenderer.material = ShaderManager.shm.dissolve;
				GameObject ashes = PoolManager.pm.ashesPool.GetPooledGameObject();
				ashes.SetActive(true);
				ashes.transform.position = transform.position;
				dissolve.isDissolving = true;
			}

			if (dmgType == "Physical") {
				GameObject blood = PoolManager.pm.bloodPool.GetPooledGameObject();
				blood.transform.position = transform.position;
				blood.SetActive(true);
			}

			if (dmgType == "Fire") {
				GameObject fire = PoolManager.pm.firePool.GetPooledGameObject();
				fire.SetActive(true);
				fire.transform.position = transform.position;
			}
			
			moveSpeed = 0f;
			Instantiate(drop, transform.position, Quaternion.identity);
			StartCoroutine(PostponeDeath(1f));
			int deathSoundIndex = Random.Range(0, 3);
			SoundManager.sm.humanDying[deathSoundIndex].Play();
		}
	}

	private void FlipEnemySprite() {
		bool enemyMovingRight = _direction.x > 0.01f;

		if(!enemyMovingRight) {
			transform.localScale = new Vector2(1, 1);
		} else if (enemyMovingRight) {
			transform.localScale = new Vector2(-1, 1);
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

