using UnityEngine;

public class Pool : MonoBehaviour {

	public Projectile projectile;
	public ParticleSystem particleSystem;
	public BaseEnemy enemy;

	public Projectile[] projectilePool;
	public ParticleSystem[] particlePool;
	public BaseEnemy[] enemyPool;

	public int poolSize;

	private void Awake() {
		PopulatePools();
	}

	private void PopulatePools() {

		projectilePool = new Projectile[poolSize];
		particlePool = new ParticleSystem[poolSize];
		enemyPool = new BaseEnemy[poolSize];
		for (int i = 0; i < poolSize; i++) {
			projectilePool[i] = projectile;
			particlePool[i] = particleSystem;
			enemyPool[i] = enemy;
		}
	}
	public void GetFromPool() {
		
	}

	public void ReturnToPool() {
		
	}
}
