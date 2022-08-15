using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeingPedestrian : BaseEnemy {
    [SerializeField] private float _safetyTime;

    void Start() {
        playerPosition = GameObject.FindWithTag("Player").transform;
        StartCoroutine(SuccessfullyFled());
    }
    public override void MoveTowardsPlayer() {
        Vector3 temp = Vector3.MoveTowards(transform.position, playerPosition.position, -1 * moveSpeed * Time.deltaTime);
        enemyRb2D.MovePosition(temp);
    }
    private IEnumerator SuccessfullyFled() {
        yield return null;
        yield return new WaitForSeconds(_safetyTime);
        Destroy(this.gameObject);
    }
}
