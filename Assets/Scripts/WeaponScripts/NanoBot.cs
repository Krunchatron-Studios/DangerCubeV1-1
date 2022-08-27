using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanoBot : Projectile {
    public NanoManager nanoManager;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            Debug.Log("This is a pedestrian impact: " + other.gameObject.name);
            Destroy(this.gameObject);
            nanoManager.currentNanoBots--;
        }
    }
}
