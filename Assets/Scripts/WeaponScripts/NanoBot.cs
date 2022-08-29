using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NanoBot : Projectile {
    public NanoManager nanoManager;
    public float rotationSpeed;
    public GameObject playerPosition;
    // public int movementSpeed;
    private GameObject _target;
    public GameObject zombie;

    private void FixedUpdate() {
        playerPosition = GameObject.FindWithTag("Player");
        RotateNanos();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy") && other.gameObject.name == "Pedestrian(Clone)") {
            Instantiate(zombie, transform.position, Quaternion.identity);

            // StartCoroutine(ZombieCo(transform.position));
            Destroy(gameObject);
            Destroy(other);
            nanoManager.currentNanoBots--;
        }
    }
    
    private void RotateNanos() {
        Vector3 move = new Vector3(0, 0, 1);
        transform.RotateAround(playerPosition.transform.position, move, rotationSpeed * Time.deltaTime);
        // Vector3 offset = new Vector3(playerPosition.transform.position.x + 3, playerPosition.transform.position.y + 3, 0);
        // transform.position = Vector3.MoveTowards(transform.position, playerPosition.transform.position, movementSpeed);
    }

    // IEnumerator ZombieCo(Vector3 target) {
    //     yield return null;
    //     yield return new WaitForSeconds(2);
    //     MakeZombie(target);
    // }

    // void MakeZombie(Vector3 target) {
    //     Vector3 temp = new Vector3(target.x, target.y, target.z)
    // }
}
