using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour {
	public static ObjectPool op;
	public List<GameObject> pooledObjects;
	public GameObject objectToPool;
	public int amountToPool;

	void Awake() {
		op = this;
	}

	void Start() {
		pooledObjects = new List<GameObject>();
		GameObject tmp;
		for(int i = 0; i < amountToPool; i++) {
			tmp = Instantiate(objectToPool);
			tmp.SetActive(false);
			pooledObjects.Add(tmp);
			Debug.Log($"tmp2: {tmp}");

		}
	}
	
	public GameObject GetPooledObject() {
		for(int i = 0; i < amountToPool; i++) {
			if(!pooledObjects[i].activeInHierarchy) {
				return pooledObjects[i];
			}
		}
		return null;
	}
	
	// GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(); 
	// 	if (bullet != null) {
	// 	bullet.transform.position = turret.transform.position;
	// 	bullet.transform.rotation = turret.transform.rotation;
	// 	bullet.SetActive(true);
	// }
}

