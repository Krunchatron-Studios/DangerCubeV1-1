using MoreMountains.Tools;
using UnityEngine;

namespace Managers {
	public class EnemyPoolManager : MonoBehaviour {

		public static EnemyPoolManager epm;

		private void Start() {
			epm = this;
		}
		[Header("Enemy Pools")] 
		public MMSimpleObjectPooler[] allPedestrians;
		public MMSimpleObjectPooler FemPed1Pool;
		public MMSimpleObjectPooler MalePed1Pool;
		public MMSimpleObjectPooler pedGroupPool;
		public MMSimpleObjectPooler pedGroupPool2;
		public MMSimpleObjectPooler helicopterPool;
		public MMSimpleObjectPooler soldierPool;

		[Header("Particles")] 
		public MMSimpleObjectPooler shieldHit;
		public MMSimpleObjectPooler machineGunMuzzle;

		[Header("Enemy Projectiles")]
		public MMSimpleObjectPooler enemyBulletPool;
	}
}
