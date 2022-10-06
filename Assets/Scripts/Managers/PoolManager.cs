using MoreMountains.Tools;
using UnityEngine;

namespace Managers {
	public class PoolManager : MonoBehaviour {
		public static PoolManager pm;

		private void Start() {
			pm = this;
		}

		[Header("Particle Pools")] 
		public MMSimpleObjectPooler ashesPool;
		public MMSimpleObjectPooler bloodPool;
		public MMSimpleObjectPooler acidBlastPool;
		public MMSimpleObjectPooler laserSwirlPool;

		[Header("Muzzle Flashes")] 
		public MMSimpleObjectPooler plasmaBursterMuzzle;
		public MMSimpleObjectPooler clusterCannonMuzzle;
		public MMSimpleObjectPooler mineSlayerMuzzle;
		public MMSimpleObjectPooler orbitalLaserMuzzle;
		public MMSimpleObjectPooler nanoBotsMuzzle;
		
		[Header("Impact Particles")]
		public MMSimpleObjectPooler plasmaBursterImpact;
		public MMSimpleObjectPooler clusterCannonImpact;
		public MMSimpleObjectPooler mineSlayerImpact;
		public MMSimpleObjectPooler orbitalLaserImpact;
		public MMSimpleObjectPooler nanoBotsImpact;
		
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
}
