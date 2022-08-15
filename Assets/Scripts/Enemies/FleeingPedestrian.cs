using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeingPedestrian : BaseEnemy
{
    public override void MoveTowardsPlayer()
    {
        Vector3 temp = Vector3.MoveTowards(transform.position, _playerPosition.position, -1 * _speed * Time.deltaTime);
        _enemyRB.MovePosition(temp);
    }
}
