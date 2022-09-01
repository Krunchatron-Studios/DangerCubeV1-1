using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using Unity.VisualScripting;
using UnityEngine;

public class NanoZombie : MonoBehaviour {
    private Vector3 _target;
    private int moveSpeed = 1;
    private int damage = 1;
    public int lifeTime = 5;
    public int chaseRadius = 3;
    public GameObject bloodSplash;
    void Awake() {
        StartCoroutine(ZombieLife());
    }
    private void Update() {
        ChaseEnemy();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position, 
                damage.ToString(), Vector3.up, .2f);
            // bloodSplash = Instantiate(bloodSplash, other.transform.position, Quaternion.identity);
            IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
            hit.TakeDamage(damage);
        }
    }

    private void ChaseEnemy() {
        Collider2D foundObject = Physics2D.OverlapCircle(transform.position, chaseRadius);
        if (foundObject.CompareTag("Enemy")) {
            _target = foundObject.transform.position;
            MoveTowards();
        }
    }

    private void MoveTowards() {
        transform.position = Vector3.MoveTowards(transform.position, _target, moveSpeed);
    }

    IEnumerator ZombieLife() {
        yield return null;
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
