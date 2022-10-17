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
		public MMSimpleObjectPooler firePool;
		public MMSimpleObjectPooler plasmaPool;
		public MMSimpleObjectPooler acidBurnPool;
		public MMSimpleObjectPooler acidBlastPool;
		public MMSimpleObjectPooler laserSwirlPool;
		
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
