using System.Collections.Generic;
using UnityEngine;

namespace ScriptableCode {
	[CreateAssetMenu(fileName = "UnlockData", menuName = "ScriptableObjects/UnlockData")]
	public class UnlockData : ScriptableObject {

		public Dictionary<string, bool> allUnlocks = new Dictionary<string, bool>();
	}
}