using Managers;
using UnityEngine;

public class CombinedStructure : MonoBehaviour {

	public int evacuateThreshold = 10;
	public int buildingSize = 1;
	public bool hasEvacuated;
	public BasicStructure[] structurePiecesArray;
	public GameObject[] fireAndSmokeDamageArray;
	
	public void EvacuateBuilding(int groupsToEvacuate) {
		hasEvacuated = true;
		for (int i = 0; i < groupsToEvacuate; i++) {
			int pedestrianIndex = Random.Range(0, PoolManager.pm.allPedestrians.Length);
			GameObject evacGroup = PoolManager.pm.allPedestrians[pedestrianIndex].GetPooledGameObject();
			evacGroup.SetActive(true);
			evacGroup.transform.position = transform.position;
		}
	}
}
