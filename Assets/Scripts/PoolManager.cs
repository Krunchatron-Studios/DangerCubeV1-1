using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

public class PoolManager : MonoBehaviour {

	[Header("Particle")]
	public MMSimpleObjectPooler bloodPool, ashesPool, rapidGunPool, clusterGunPool;

	[Header("Enemy")] 
	public MMSimpleObjectPooler pedestrianPool, soldierPool, heliPool, kiwikidPool;
	
	
}
