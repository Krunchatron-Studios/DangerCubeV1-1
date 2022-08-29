using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MutagenicNanobots : Weapon {
    public NanoManager nanoManager;
    public GameObject playerPosition;
    public Transform center;
    public GameObject nanoBot;
    public float spawnDelay;

    void Start() {
        playerPosition = GameObject.FindWithTag("Player");
        center = playerPosition.transform;
        nanoManager.currentNanoBots = 0;
        SpawnNanos();
    }
    void FixedUpdate() {
        playerPosition = GameObject.FindWithTag("Player");
        center = playerPosition.transform;
    }

    private void SpawnNanos() {
        if (nanoManager.currentNanoBots < nanoManager.maxNanoBots) {
            Vector3 offset = new Vector3(center.position.x, center.position.y + 3, 0);
            Instantiate(nanoBot, offset, Quaternion.identity);
            nanoManager.currentNanoBots++;
            StartCoroutine(SpawnCo());
        }
    }

    IEnumerator SpawnCo() {
        yield return null;
        yield return new WaitForSeconds(spawnDelay);
        SpawnNanos();
    }
}
