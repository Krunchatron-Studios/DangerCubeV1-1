using System;
using System.Collections;
using UnityEngine;

public class MechanicalMeatSeparator : Weapon {
    
    public GameObject sawProjectile;
    public GameObject playerObject;
    public int numberOfSpins;

    private void Start() {
        StartCoroutine(SpinSaw());
    }
    
    IEnumerator SpinSaw() {
        sawProjectile.SetActive(true);

        float time = 0f;
        while (time < numberOfSpins) {
            time += Time.deltaTime;
            transform.RotateAround(playerObject.transform.position, Vector3.forward, 360 * Time.deltaTime);
            yield return null;
        }       
        sawProjectile.SetActive(false);
        StartCoroutine(FireTimer());
    }

    IEnumerator FireTimer() {
        yield return new WaitForSeconds(attackSpeed);
        StartCoroutine(SpinSaw());
    }
}
