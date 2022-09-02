using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using Unity.VisualScripting;
using UnityEngine;

public class NanoZombie : MonoBehaviour {
    private Transform _target;
    private int moveSpeed = 20;
    private int damage = 5;

    private void FixedUpdate() {
        _target = GameObject.FindWithTag("Enemy").transform;
        MoveTowards();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position, 
                damage.ToString(), Vector3.up, .2f);
            // bloodSplash = Instantiate(bloodSplash, other.transform.position, Quaternion.identity);
            IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
            hit.TakeDamage(damage, "Physical");
        }
    }

    private void MoveTowards() {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, moveSpeed);
    }
}
