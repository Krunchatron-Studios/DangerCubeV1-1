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
        transform.localScale = GameManager.gm.playerCube.transform.localScale;
        Vector3 moveDirection = (_enemyPosition.transform.position - transform.position).normalized;
        thisRigidBody.AddForce(moveDirection * sawVelocity * Time.deltaTime, ForceMode2D.Impulse);
    }
}
