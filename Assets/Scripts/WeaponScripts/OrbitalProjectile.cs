using System;
using System.Collections;
using System.Collections.Generic;
using Lofelt.NiceVibrations;
using UnityEngine;

public class OrbitalProjectile : Projectile {
    private AudioSource audio;

    private void Awake() {
        Sound();
    }

    public override void ResolveProjectile(Collider2D other) {
        if (other.CompareTag("Enemy")) {
				
            IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
            hit.TakeDamage(weapon.weaponDamage);
        }
        if (other.CompareTag("Wall")) {
        }
    }

    void Sound() {
        audio.Play();
    } 
}
