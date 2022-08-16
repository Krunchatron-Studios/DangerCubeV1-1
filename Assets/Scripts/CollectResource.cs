using UnityEngine;

public class CollectResource : MonoBehaviour {

    public int value = 2;
    public PlayerResources playerResources;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && this.CompareTag("BioGoo")) {
            playerResources.bioGoo += value;
            Destroy(gameObject);
        } else if (other.CompareTag("Player") && this.CompareTag("Metal")) {
            playerResources.metal += value;
            Destroy(gameObject);
        } else if (other.CompareTag("Player") && this.CompareTag("Silicate")) {
            playerResources.silicate += value;
            Destroy(gameObject);
        }
       
    }
}
