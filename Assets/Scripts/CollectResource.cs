using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectResource : MonoBehaviour {

    public int value = 2;
    public PlayerResources PlayerResources;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            PlayerResources.bioGoo += value;
            Destroy(this.gameObject);
        }
       
    }
}
