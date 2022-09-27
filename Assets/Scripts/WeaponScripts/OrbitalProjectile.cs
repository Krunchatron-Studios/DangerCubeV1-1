using Interfaces;
using MoreMountains.Tools;
using UnityEngine;

public class OrbitalProjectile : MonoBehaviour {
    //
    // public GameObject bloodSplash;
    // public Weapon weapon;
    // public void OnTriggerEnter2D(Collider2D other) {
    //     if (other.CompareTag("Enemy")) {
    //         MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position, 
    //             weapon.weaponDamage.ToString(), Vector3.up, .2f);
    //         IHurtThingsInterface hit = other.GetComponent<IHurtThingsInterface>();
    //         hit.TakeDamage(weapon.weaponDamage, weapon.damageType);
    //         bloodSplash = PoolManager.pm.bloodPool.GetPooledGameObject();
    //         bloodSplash.SetActive(true);
    //         bloodSplash.transform.position = other.transform.position;
    //     }
    //     
    //     if (other.CompareTag("Obstacle")) {
    //         ISmashThingsInterface hit = other.GetComponent<ISmashThingsInterface>();
    //         hit.DamageStructure(weapon.weaponDamage, weapon.damageType, other.transform.position);
    //         gameObject.SetActive(false);
    //     }
    // }
}
