using UnityEngine;

namespace Interfaces {
	public interface IHurtThingsInterface {
		public void TakeDamage(float damageAmount, string damageType);
		public void GetDamage(GameObject other);
	}
}
