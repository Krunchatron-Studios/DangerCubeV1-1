using Managers;
using UnityEngine;

public class CombinedStructure : MonoBehaviour {

	public int evacuateThreshold = 10;
	public int buildingSize = 1;
	public bool hasEvacuated;
	public bool stage1Crumble, stage2Crumble;
	public BasicStructure[] structurePiecesArray;
	public GameObject[] fireAndSmokeDamageArray;
	public GameObject[] escapePoints;
	
	public void EvacuateBuilding(int groupsToEvacuate) {
		hasEvacuated = true;
		for (int i = 0; i < groupsToEvacuate; i++) {
			int pedestrianIndex = Random.Range(0, EnemyPoolManager.epm.allPedestrians.Length -1);
			GameObject evacGroup = EnemyPoolManager.epm.allPedestrians[pedestrianIndex].GetPooledGameObject();
			evacGroup.SetActive(true);
			int index = Random.Range(0, escapePoints.Length);
			evacGroup.transform.position = escapePoints[index].transform.position;
		}
						
		if (!stage1Crumble) {
			SoundManager.sm.buildingCrumbleSounds[1].Play();
			stage1Crumble = true;
		}
	}
}
