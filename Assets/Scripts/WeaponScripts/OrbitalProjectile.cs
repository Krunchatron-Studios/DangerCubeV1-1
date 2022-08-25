using MoreMountains.Tools;
using UnityEngine;

public class OrbitalProjectile : MonoBehaviour {

    public GameObject bloodSplash;
    public Weapon weapon;
    public void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position, 
                weapon.weaponDamage.ToString(), Vector3.up, .2f);
            bloodSplash = Instantiate(bloodSplash, other.transform.position, Quaternion.identity);
            IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
            hit.TakeDamage(weapon.weaponDamage);
        }
    }
}
