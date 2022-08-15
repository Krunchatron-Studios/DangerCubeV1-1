using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectResource : MonoBehaviour {
    
    public int bioGoo = 0;
    public int metal = 0;
    public int silicate = 0;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            switch (gameObject.name) {
                case "SmallBioGoo(Clone)":
                    Debug.Log(bioGoo);
                    bioGoo += 1;
                    Debug.Log("You have " + bioGoo + " small bio goo.");
                    break;
                case "MediumBioGoo(Clone)":
                    bioGoo += 5;
                    break;
                case "LargeBioGoo(Clone)":
                    bioGoo += 10;
                    break;
                case "SmallMetal(Clone)":
                    metal++;
                    break;
                case "MediumMetal(Clone)":
                    metal += 5;
                    break;
                case "LargeMetal(Clone)":
                    metal += 10;
                    break;
                case "SmallSilicate(Clone)":
                    silicate++;
                    break;
                case "MediumSilicate(Clone)":
                    silicate += 5;
                    break;
                case "LargeSilicate(Clone)":
                    silicate += 10;
                    break;
            }
        }
    }
}
