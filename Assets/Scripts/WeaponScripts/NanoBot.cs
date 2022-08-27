using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanoBot : Projectile {

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            Debug.Log("This is a pedestrian impact: " + other.gameObject.name);
        }
    }
}
