using UnityEngine;

namespace Interfaces {
	public interface ISmashThingsInterface {
		public void DamageStructure(float damageAmount, string damageType, Vector3 location);
	}
}