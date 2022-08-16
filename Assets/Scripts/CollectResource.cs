using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectResource : MonoBehaviour {

    public int value = 2;
    public PlayerResources playerResources;
    // void Awake() {
    //     playerResources.bioGoo = 0;
    //     playerResources.metal = 0;
    //     playerResources.silicate = 0;
    //     playerResources.experience = 0;
    // }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && this.CompareTag("BioGoo")) {
            playerResources.bioGoo += value;
            Destroy(this.gameObject);
        } else if (other.CompareTag("Player") && this.CompareTag("Metal")) {
            playerResources.metal += value;
            Destroy(this.gameObject);
        } else if (other.CompareTag("Player") && this.CompareTag("Silicate")) {
            playerResources.silicate += value;
            Destroy(this.gameObject);
        }
       
    }
}
