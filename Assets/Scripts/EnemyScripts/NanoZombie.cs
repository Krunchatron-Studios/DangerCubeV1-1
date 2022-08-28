using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NanoZombie : MonoBehaviour {
    private Transform _target;
    private int moveSpeed = 20;

    private void FixedUpdate() {
        _target = GameObject.FindWithTag("Enemy").transform;
        MoveTowards();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Zombie Gotcha!!!");
    }

    private void MoveTowards() {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, moveSpeed);
    }
}
