using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : BaseEnemy
{
    public override void MoveTowardsPlayer()
    {
        Vector3 temp = Vector3.MoveTowards(transform.position, _playerPosition.position, _speed * Time.deltaTime);
        _enemyRB.MovePosition(temp);
    }
}
