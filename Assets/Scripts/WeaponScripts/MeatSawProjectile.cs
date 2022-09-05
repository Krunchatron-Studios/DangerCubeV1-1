using UnityEngine;
using MoreMountains.Tools;

public class MeatSawProjectile : MonoBehaviour {
    public int damage;
    public GameObject bloodSplash;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
            hit.TakeDamage(damage, "Physical");
            SoundManager.sm.meatSaw.Play();
            MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position, 
                damage.ToString(), Vector3.up, .2f);
            bloodSplash = PoolManager.pm.bloodPool.GetPooledGameObject();
            bloodSplash.SetActive(true);
            bloodSplash.transform.position = other.transform.position;
        }
    }
}
