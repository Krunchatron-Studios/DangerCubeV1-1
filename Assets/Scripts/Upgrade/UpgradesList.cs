using System.Collections.Generic;
using UnityEngine;

public class UpgradesList : MonoBehaviour {

	public static UpgradesList ul;
	private void Start() {
		ul = this;
	}

	public List<Upgrade> techList = new List<Upgrade>();
}
