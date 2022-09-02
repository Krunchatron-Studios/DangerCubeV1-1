using System;
using MoreMountains.Tools;
using UnityEngine;

public class PoolManager : MonoBehaviour {
	public static PoolManager pm;

	private void Start() {
		pm = this;
	}

	[Header("Enemy Pools")] 
	public MMSimpleObjectPooler pedestrianPool;

	[Header("Projectile Pools")] 
	public MMSimpleObjectPooler clusterPool;

	[Header("Particle Pools")] 
	public MMSimpleObjectPooler ashesPool;

	public MMSimpleObjectPooler bloodPool;
}
