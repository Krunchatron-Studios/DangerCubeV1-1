using MoreMountains.Tools;
using UnityEngine;

namespace Managers {
	public class EnemyPoolManager : MonoBehaviour {

		public static EnemyPoolManager epm;

		private void Start() {
			epm = this;
		}

		[Header("Muzzle Flashes")] 
		public MMSimpleObjectPooler mgFlashPool;

		[Header("Enemy Projectiles")]
		public MMSimpleObjectPooler enemyBulletPool;
	}
}
