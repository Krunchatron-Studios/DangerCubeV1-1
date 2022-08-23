using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicalMeatSeparator : MonoBehaviour {
    private GameObject _enemyPosition;
    public Rigidbody2D thisRigidBody;
    public float sawVelocity;
    void Start() {
        _enemyPosition = GameObject.FindWithTag("Enemy");
    }
    void Update() {
        _enemyPosition = GameObject.FindWithTag("Enemy");
        MoveSaw();
    }

    void MoveSaw() {
        Vector3 moveDirection = (_enemyPosition.transform.position - transform.position).normalized;
        thisRigidBody.AddForce(moveDirection * sawVelocity * Time.deltaTime, ForceMode2D.Impulse);
    }
}
