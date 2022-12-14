using UnityEngine;

public class EKiteEnemy : BaseEnemy {
    public Transform playerPosition;
    public int kiteDistance = 4;
    public Transform enemyPosition;
    public void MoveTowardsPlayer() {
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
