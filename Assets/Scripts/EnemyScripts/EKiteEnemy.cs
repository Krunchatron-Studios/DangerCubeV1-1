using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EKiteEnemy : BaseEnemy {
    public int kiteDistance = 4;
    public Transform enemyPosition;
    public override void MoveTowardsPlayer() {
        float distance = Vector3.Distance(enemyPosition.position, playerPosition.position);
        if (enemyPosition && distance > kiteDistance) {
            Vector3 temp = Vector3.MoveTowards(transform.position, playerPosition.position, moveSpeed * Time.deltaTime);
            enemyRb2D.MovePosition(temp);
        } else if (enemyPosition && distance < kiteDistance) {
            Vector3 temp = Vector3.MoveTowards(transform.position, playerPosition.position, moveSpeed * -1 * Time.deltaTime);
            enemyRb2D.MovePosition(temp);
        }
    }
}
