using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour {
    [Header("Player Position")]
    public Transform playerPosition;
    [Header("Weapon Paramters")]
    public int enemyDamage;
    public int fireRange;
    public int fireTimer;
    public int bulletVelocity;
    public bool canFire = true;
    [Header("Projectile Parameters")]
    public GameObject enemyProjectile;
    private Rigidbody2D _projectileBody;
    void FixedUpdate() {
        playerPosition = GameObject.FindWithTag("Player").transform;
        ShootPlayer();
    }

    public void ShootPlayer() {
        float distance = Vector3.Distance(playerPosition.position, transform.position);
        if (distance <= fireRange && canFire == true) {
            GameObject bullet = Instantiate(enemyProjectile, transform.position, Quaternion.identity);
            _projectileBody = bullet.GetComponent<Rigidbody2D>();
            Vector3 moveDirection = (playerPosition.position - transform.position).normalized;
            _projectileBody.AddForce(moveDirection * bulletVelocity * Time.deltaTime, ForceMode2D.Impulse);
            StartCoroutine(ToggleCo());
        }
    }
    IEnumerator ToggleCo() {
        canFire = false;
        yield return new WaitForSeconds(fireTimer);
        canFire = true;
    }
}
