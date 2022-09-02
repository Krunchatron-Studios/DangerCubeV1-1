using MoreMountains.Tools;
using UnityEngine;

public class Pool : MonoBehaviour {
	public MMSimpleObjectPooler objectPooler;

	public void SpawnObject() {
		GameObject newObject = objectPooler.GetPooledGameObject();
		newObject.transform.position = transform.position;
		newObject.SetActive(true);
	}
}
