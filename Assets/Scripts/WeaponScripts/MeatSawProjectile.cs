using UnityEngine;
using MoreMountains.Tools;

public class MeatSawProjectile : MonoBehaviour {
    public int damage;
    public GameObject bloodSplash;
    public AudioSource audioSource;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
            hit.TakeDamage(damage, "Physical");
            audioSource.Play();
            MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position, 
                damage.ToString(), Vector3.up, .2f);
            // bloodSplash = Instantiate(bloodSplash, other.transform.position, Quaternion.identity);
        }
    }
}
