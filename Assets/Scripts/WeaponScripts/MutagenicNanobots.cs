using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MutagenicNanobots : Weapon {
    public NanoManager nanoManager;
    public GameObject playerPosition;
    public Transform center;
    public GameObject nanoBot;
    public List<GameObject> allNanos = new List<GameObject>();
    public float rotationSpeed;

    void Start() {
        nanoManager.currentNanoBots = 0;
    }
    void FixedUpdate() {
        playerPosition = GameObject.FindWithTag("Player");
        center = playerPosition.transform;
        SpawnNanos();
        RotateNanos();
    }

    private void SpawnNanos() {
        for (int i = nanoManager.currentNanoBots; i <= nanoManager.maxNanoBots; i++) {
            Vector3 offset = new Vector3(center.position.x, center.position.y + 3, 0);
            GameObject thisNano = Instantiate(nanoBot, offset, Quaternion.identity);
            allNanos.Add(thisNano);
            nanoManager.currentNanoBots++;
        }
    }

    private void RotateNanos() {
        foreach (GameObject thisNano in allNanos) {
            Vector3 direction = new Vector3(0, 1, 0);
            thisNano.transform.RotateAround(center.position, direction, rotationSpeed * Time.deltaTime);
            // thisNano.transform.position = Vector3.MoveTowards(transform.position, center.position, rotationSpeed);
        }
    }
}
