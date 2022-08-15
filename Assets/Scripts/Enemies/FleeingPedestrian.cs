using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeingPedestrian : BaseEnemy
{
    [SerializeField] private float _safetyTime;

    void Start()
    {
        _playerPosition = GameObject.FindWithTag("Player").transform;
        StartCoroutine(SuccessfullyFled());
    }
    public override void MoveTowardsPlayer()
    {
        Vector3 temp = Vector3.MoveTowards(transform.position, _playerPosition.position, -1 * _speed * Time.deltaTime);
        _enemyRB.MovePosition(temp);
    }
    // comment for testing
    private IEnumerator SuccessfullyFled()
    {
        yield return null;
        yield return new WaitForSeconds(_safetyTime);
        Destroy(this.gameObject);
    }
}
