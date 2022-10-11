using System;
using UnityEngine;

public class NanoBot : Projectile {
    public MutagenicNanobots nanoWeapon;
    public GameObject rotationCenter;
    private Vector3 _nanoTransform;
    [Header("Mutation Payload")]
    public NanoZombie[] zombies;
    public NanoZombie zombie;

    private void Update() {
        _nanoTransform = transform.position;
        transform.RotateAround(rotationCenter.transform.position, Vector3.forward, projectileVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<EFleeingPedestrian>()) {
            String temp = other.GetComponent<EFleeingPedestrian>().enemyName;
            if (other.CompareTag("Enemy") && temp == "Pedestrian") {
                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
                nanoWeapon.currentNanos--;
                OnDisable();
            }
        }
    }
    private void OnDisable() {
        GameObject nano = weapon.objectPooler.GetPooledGameObject();
        nano.transform.position = transform.position;
        nano.SetActive(true);

        // int temp = zombie.currentZombies;
        // for(int i = 0; i < zombies.Length; i++) {
        //     if (!zombies[i].gameObject.activeInHierarchy) {
        //         zombies[i].gameObject.transform.position = transform.position;
        //         zombies[i].gameObject.SetActive(true);
        //         
        //         zombie.currentZombies++;
        //     }
        // }
    }
}
