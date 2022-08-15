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
                    bioGoo++;
                    Debug.Log("Collect " + bioGoo + " bio goo.");
                    Destroy(this.gameObject);
                    break;
                case "MediumBioGoo(Clone)":
                    bioGoo += 5;
                    Debug.Log("Collect " + bioGoo + " bio goo.");
                    Destroy(this.gameObject);
                    break;
                case "LargeBioGoo(Clone)":
                    bioGoo += 10;
                    Debug.Log("Collect " + bioGoo + " bio goo.");
                    Destroy(this.gameObject);
                    break;
                case "SmallMetal(Clone)":
                    metal++;
                    Debug.Log("Collect " + metal + " bio goo.");
                    Destroy(this.gameObject);
                    break;
                case "MediumMetal(Clone)":
                    metal += 5;
                    Debug.Log("Collect " + metal + " bio goo.");
                    Destroy(this.gameObject);
                    break;
                case "LargeMetal(Clone)":
                    metal += 10;
                    Debug.Log("Collect " + metal + " bio goo.");
                    Destroy(this.gameObject);
                    break;
                case "SmallSilicate(Clone)":
                    silicate++;
                    Debug.Log("Collect " + silicate + " bio goo.");
                    Destroy(this.gameObject);
                    break;
                case "MediumSilicate(Clone)":
                    silicate += 5;
                    Debug.Log("Collect " + silicate + " bio goo.");
                    Destroy(this.gameObject);
                    break;
                case "LargeSilicate(Clone)":
                    silicate += 10;
                    Debug.Log("Collect " + silicate + " bio goo.");
                    Destroy(this.gameObject);
                    break;
            }

           
        }
    }
}
