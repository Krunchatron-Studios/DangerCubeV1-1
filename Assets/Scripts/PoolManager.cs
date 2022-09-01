using MoreMountains.Tools;
using UnityEngine;

public class PoolManager : MonoBehaviour {

	public static PoolManager pm;
	
	[Header("Particle")]
	public ParticlePool bloodPool, ashesPool, rapidGunPool, clusterGunPool;

	[Header("Enemy")] 
	public ObjectPool pedestrianPool, soldierPool, heliPool, kiwikidPool;

	private void Start() {
		pm = this;
	}
}

