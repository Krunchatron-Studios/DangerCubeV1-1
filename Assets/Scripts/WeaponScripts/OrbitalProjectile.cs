using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalProjectile : Projectile
{
    public override void ResolveProjectile(Collider2D other) {
        if (other.CompareTag("Enemy")) {
				
            IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
            hit.TakeDamage(weapon.weaponDamage);
        }
        if (other.CompareTag("Wall")) {
        }
    }
}
