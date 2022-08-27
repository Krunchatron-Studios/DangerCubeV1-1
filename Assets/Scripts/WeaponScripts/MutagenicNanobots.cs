using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MutagenicNanobots : Weapon
{  
    public int maxNanoBots;
    public int currentNanoBots;
    public GameObject playerPosition;
    public Transform center;
    public GameObject nanoBot;
    public float rotationSpeed;

    void FixedUpdate() {
        playerPosition = GameObject.FindWithTag("Player");
        center = playerPosition.transform;
        SpawnNanos();
    }

    private void SpawnNanos() {
        if (currentNanoBots < maxNanoBots) {
            Vector3 offset = new Vector3(center.position.x, center.position.y + 3, 0);
            GameObject thisNano = Instantiate(nanoBot, offset, Quaternion.identity);
            currentNanoBots++;
            RotateNanos(thisNano);
        } 
    }

    private void RotateNanos(GameObject thisNano) {
        thisNano.transform.RotateAround(center.position, Vector3.left, rotationSpeed * Time.deltaTime);
       
    }
}
