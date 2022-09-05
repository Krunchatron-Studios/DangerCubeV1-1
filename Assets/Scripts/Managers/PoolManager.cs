using MoreMountains.Tools;
using UnityEngine;

public class PoolManager : MonoBehaviour {
	public static PoolManager pm;

	private void Start() {
		pm = this;
	}

	[Header("Enemy Pools")] 
	public MMSimpleObjectPooler pedestrianPool;
	public MMSimpleObjectPooler helicopterPool;

	[Header("Projectile Pools")] 
	public MMSimpleObjectPooler clusterPool;
	public MMSimpleObjectPooler acidMinePool;
	public MMSimpleObjectPooler rapidPool;
	public MMSimpleObjectPooler nanoPool;
	

	[Header("Particle Pools")] 
	public MMSimpleObjectPooler ashesPool;
	public MMSimpleObjectPooler bloodPool;
	public MMSimpleObjectPooler acidBlastPool;

	[Header("Resource Pools")] 
	public MMSimpleObjectPooler sBioGooPool;
	public MMSimpleObjectPooler mBioGooPool;
	public MMSimpleObjectPooler lBioGooPool;

	public MMSimpleObjectPooler sMetal;
	public MMSimpleObjectPooler mMetal;
	public MMSimpleObjectPooler lMetal;

	public MMSimpleObjectPooler sSilicate;
	public MMSimpleObjectPooler mSilicate;
	public MMSimpleObjectPooler lSilicate;

	
}
