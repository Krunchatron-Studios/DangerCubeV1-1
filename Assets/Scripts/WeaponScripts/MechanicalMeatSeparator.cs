using UnityEngine;

public class MechanicalMeatSeparator : Weapon {
    private GameObject _enemyPosition;
    public Rigidbody2D thisRigidBody;
    public float sawVelocity;
    void Start() {
        _enemyPosition = GameObject.FindWithTag("Enemy");
    }
    void Update() {
        // Does the enemies position even matter for this?
        _enemyPosition = GameObject.FindWithTag("Enemy");
        MoveSaw();
    }

    void MoveSaw() {
        Vector2 direction = (_enemyPosition.transform.position - transform.position).normalized;
        bool weaponRenderer = GetComponentInParent<SpriteRenderer>().flipX;
        weaponRenderer = direction.x < 0;
        Vector3 moveDirection = (_enemyPosition.transform.position - transform.position).normalized;
        thisRigidBody.AddForce(moveDirection * sawVelocity * Time.deltaTime, ForceMode2D.Impulse);
    }
}
