using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ParticlePool : ObjectPool {
	public static ParticlePool pp;
	public List<ParticleSystem> pooledParticles;
	public ParticleSystem particleToPool;
	public int particleAmountToPool;

	void Awake() {
		pp = this;
	}

	void Start() {
		pooledParticles = new List<ParticleSystem>();
		ParticleSystem tmp;
		for(int i = 0; i < amountToPool; i++) {
			tmp = Instantiate(particleToPool);
			tmp.Stop();
			pooledParticles.Add(tmp);
			Debug.Log($"tmp: {tmp}");
		}
	}
	
	public ParticleSystem GetPooledParticle() {
		for(int i = 0; i < amountToPool; i++) {
			if(!pooledParticles[i].gameObject.activeInHierarchy) {
				return pooledParticles[i];
			}
		}
		return null;
	}
	
	// GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(); 
	// 	if (bullet != null) {
	// 	bullet.transform.position = turret.transform.position;
	// 	bullet.transform.rotation = turret.transform.rotation;
	// 	bullet.SetActive(true);
	// }
}