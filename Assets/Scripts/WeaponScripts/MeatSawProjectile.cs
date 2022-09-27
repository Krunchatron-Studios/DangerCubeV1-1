using Interfaces;
using Managers;
using UnityEngine;
using MoreMountains.Tools;

public class MeatSawProjectile : MonoBehaviour {
    public int damage;
    public GameObject bloodSplash;
    public AudioSource audioSource;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            audioSource.Play();
            IHurtThingsInterface hit = other.GetComponent<IHurtThingsInterface>();
            hit.TakeDamage(damage, "Physical");
            MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position, 
                damage.ToString(), Vector3.up, .2f);
            bloodSplash = PoolManager.pm.bloodPool.GetPooledGameObject();
            bloodSplash.SetActive(true);
            bloodSplash.transform.position = other.transform.position;
        }
        
        if (other.CompareTag("Obstacle")) {
            ISmashThingsInterface hit = other.GetComponent<ISmashThingsInterface>();
            hit.DamageStructure(damage, "Physical", other.transform.position);
        }
    }
}
