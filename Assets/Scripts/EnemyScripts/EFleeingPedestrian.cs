using System.Collections;
using UnityEngine;

public class EFleeingPedestrian : BaseEnemy {
    [SerializeField] private Transform playerPosition;
    [SerializeField] private float _safetyTime = 10f;
    private GameObject _enemy;
    void Start() {
        playerPosition = GameObject.FindWithTag("Player").transform;
        StartCoroutine(SuccessfullyFled());
    }
    public void MoveTowardsPlayer() {
        Vector3 temp = Vector3.MoveTowards(transform.position, playerPosition.position, -1 * moveSpeed * Time.deltaTime);
            enemyRb2D.MovePosition(temp);
    }
    private IEnumerator SuccessfullyFled() {
        yield return null;
        yield return new WaitForSeconds(_safetyTime);
        gameObject.SetActive(false);
    }
}