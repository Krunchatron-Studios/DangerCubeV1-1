using Interfaces;
using Managers;
using MoreMountains.Tools;
using UnityEngine;

public class OrbitalProjectile : Projectile {
    public override void ResolveProjectile(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            IHurtThingsInterface hit = other.GetComponent<IHurtThingsInterface>();
            hit.TakeDamage(damage, weapon.damageType);
            MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position, 
                damage.ToString(), Vector3.up, .2f);
            BloodSplash(other);
            // gameObject.SetActive(false);
        }
        if (other.CompareTag("Obstacle")) {
            ISmashThingsInterface hit = other.GetComponent<ISmashThingsInterface>();
            // Debug.Log($"Damage: {damage}");
            hit.DamageStructure(damage, weapon.damageType, other.transform.position);
            // gameObject.SetActive(false);
        }
        if (other.CompareTag("Wall")) {
            // gameObject.SetActive(false);
        }
    }
}
