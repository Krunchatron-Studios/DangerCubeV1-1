using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicalMeatSeparator : MonoBehaviour {
    // public Joint2D sawHardPoint;

    private GameObject _enemyPosition;

    public Rigidbody2D thisRigidBody;

    public float sawVelocity;

    public float damage;
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
