using MoreMountains.Tools;
using UnityEngine;

public class PoolManager : MonoBehaviour {
	public static PoolManager pm;

	private void Start() {
		pm = this;
	}

	[Header("Enemy Pools")] 
	public MMSimpleObjectPooler pedestrianPool;
	public MMSimpleObjectPooler pedestrianPool2;
	public MMSimpleObjectPooler pedestrianPool3;
	public MMSimpleObjectPooler childPool;
	public MMSimpleObjectPooler pedGroupPool;
	public MMSimpleObjectPooler pedGroupPool2;
	public MMSimpleObjectPooler helicopterPool;
	public MMSimpleObjectPooler soldierPool;
	
	
	[Header("Particle Pools")] 
	public MMSimpleObjectPooler ashesPool;
	public MMSimpleObjectPooler bloodPool;
	public MMSimpleObjectPooler acidBlastPool;

	[Header("Structure Particle Pools")] 
	public MMSimpleObjectPooler softDustPool;
	public MMSimpleObjectPooler rockShatterPool;
	public MMSimpleObjectPooler glassShatterPool;

	[Header("Resource Pools")] 
	public MMSimpleObjectPooler sBioGooPool;
	public MMSimpleObjectPooler mBioGooPool;
	public MMSimpleObjectPooler lBioGooPool;

	public MMSimpleObjectPooler sMetalPool;
	public MMSimpleObjectPooler mMetalPool;
	public MMSimpleObjectPooler lMetalPool;

	public MMSimpleObjectPooler sSilicatePool;
	public MMSimpleObjectPooler mSilicatePool;
	public MMSimpleObjectPooler lSilicatePool;
}
