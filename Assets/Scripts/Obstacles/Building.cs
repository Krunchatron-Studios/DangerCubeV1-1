using Managers;
using UnityEngine;

public class Building : BasicStructure {

	public virtual void DamageTiersCheck3(Vector3 location) {
		if (percentDestroyed < stage3Threshold && stage3Dmg) {
			spriteRenderer.sprite = stage3Dmg;

			if (structureType == "Building") {
				GameObject buildingLoot = PoolManager.pm.sSilicatePool.GetPooledGameObject();
				buildingLoot.SetActive(true);
				buildingLoot.transform.position = location;
			}
		}
	}
}
