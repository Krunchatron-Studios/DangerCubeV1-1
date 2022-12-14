using UnityEngine;

namespace Interfaces {
	public interface IUpgradeThingInterface {

		public void IncreaseDamage(float dmgIncrease);
		public void IncreaseAttackSpeed(float spdIncrease);
		public void IncreaseKnock(float knkIncrease);
		public void ImproveReloadTimer(float timeReduction);
		public void IncreaseAmmoClipSize(int ammoBonus);
		public void ModifyDmgType(string dmgType);
		public void ChangeProjectile(GameObject newProjectile);
		public void IncreaseRange(int amountToIncrease);
	}
}
