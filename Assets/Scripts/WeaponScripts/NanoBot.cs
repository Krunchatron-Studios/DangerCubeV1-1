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
        int index = 0;
        int temp = zombie.currentZombies;
        while (zombie.currentZombies != temp + 1) {
            if (zombies[index].gameObject.activeInHierarchy == false) {
                zombies[index].gameObject.SetActive(true);
                zombies[index].gameObject.transform.position = _nanoTransform;
                zombie.currentZombies++;
            }
            else {
                index++;
            }
        }
    }
}
