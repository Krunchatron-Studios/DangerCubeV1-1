using System;
using System.Collections;
using UnityEngine;
public class LobbedProjectile : Projectile {
    
    public AnimationCurve xCurve, yCurve;
    private Vector3 _startPosition;
    private Rigidbody2D _thisRigidBody;
    private float _timeElapsed;
    private bool _awake;

    private void Awake() {
        _thisRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        MoveProjectile();
    }

    public override void MoveProjectile() {

        if (!_awake) {
            _awake = true;
            _timeElapsed = 0;
            _startPosition = transform.position;
        }
        else {
            _timeElapsed += Time.deltaTime;

            _thisRigidBody.MovePosition(new Vector3(
                _startPosition.x + xCurve.Evaluate(_timeElapsed / 2),
                targetPosition.y + yCurve.Evaluate(_timeElapsed / 2), 
                0));
        }
    }
}
