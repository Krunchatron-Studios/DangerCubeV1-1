using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Projectile
{
    public override void ResolveProjectile(Collider2D other) {
        if (other.CompareTag("Player")) {
				
            IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
            hit.TakeDamage(weapon.weaponDamage);
            Destroy(gameObject);
        }
        if (other.CompareTag("Wall")) {
            Destroy(gameObject);
        }
    }
}
