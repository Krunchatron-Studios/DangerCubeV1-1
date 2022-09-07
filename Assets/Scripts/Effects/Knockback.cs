using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Knockback : MonoBehaviour {
    private Rigidbody2D _thisRigidBody;
    public float knockForce;

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            Debug.Log("this is a test " + other.name);

            _thisRigidBody = other.GetComponent<Rigidbody2D>();
            Vector3 difference = (transform.position - other.transform.position).normalized;
            Vector3 appliedForce = difference * knockForce;
            _thisRigidBody.AddForce(appliedForce, ForceMode2D.Impulse);
        }
    }
}
