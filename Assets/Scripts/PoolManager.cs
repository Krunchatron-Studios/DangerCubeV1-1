using MoreMountains.Tools;
using UnityEngine;

public class PoolManager : MonoBehaviour {

	public static PoolManager pm;
	
	[Header("Particle")]
	public MMSimpleObjectPooler bloodPool, ashesPool, rapidGunPool, clusterGunPool;

	[Header("Enemy")] 
	public MMSimpleObjectPooler pedestrianPool, soldierPool, heliPool, kiwikidPool;

	private void Start() {
		pm = this;
	}
}

