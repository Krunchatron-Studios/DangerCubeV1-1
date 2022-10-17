using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffects : MonoBehaviour {

	public void PlayHitEffect(GameObject particleEffect) {
		particleEffect.SetActive(true);
		particleEffect.transform.position = transform.position;
	}

	public GameObject clusterCannonEffect;
	public GameObject plasmaBursterEffect;
	public GameObject mineSlayerEffect;
}
