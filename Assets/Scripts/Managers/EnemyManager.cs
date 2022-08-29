using UnityEngine;

public class EnemyManager : MonoBehaviour {

	[Header("Enemies")]
	public BaseEnemy pedestrian;
	public BaseEnemy soldier;
	public BaseEnemy helicopter;
	public Kiwikid kiwikid;
	
	[Header("Scriptable Objects")]
	public EnemyParticlePools enemyParticleArrays;
	public EnemyPools enemyArrays;

	private void Start() {
		PopulatePools(20);
	}

	private void PopulatePools(int poolSize) {
		enemyArrays.pedestrians = new BaseEnemy[poolSize];
		enemyArrays.soldiers = new BaseEnemy[poolSize];
		enemyArrays.helicopters = new BaseEnemy[poolSize];
		enemyArrays.kiwikids = new Kiwikid[poolSize];

		for (int i = 0; i < poolSize; i++) {
			enemyArrays.pedestrians[i] = pedestrian;
			enemyArrays.soldiers[i] = soldier;
			enemyArrays.helicopters[i] = helicopter;
			enemyArrays.kiwikids[i] = kiwikid;
			
			// enemyArrays.pedestrians[i].gameObject.SetActive(false);
			// enemyArrays.soldiers[i].gameObject.SetActive(false);
			// enemyArrays.helicopters[i].gameObject.SetActive(false);
			// enemyArrays.kiwikids[i].gameObject.SetActive(false);
		}
	}
}
