using AI;
using UnityEngine;

public class DistanceDetect : MonoBehaviour {

    public float aggroRadius = 10.0f;
    public BaseEnemy[] enemyArray;
    void Update() {
        ScanForAggro();
    }
    
    private void ScanForAggro() {
        Vector3 position = transform.position;
        bool isThereEnemies = GameObject.FindGameObjectWithTag("Enemy").activeInHierarchy;
        if (isThereEnemies) {
            for (int i = 0; i < enemyArray.Length; i++) {
                BaseEnemy currentEnemy = enemyArray[i];
                float distance = Vector3.Distance(currentEnemy.transform.position, position);
                if (distance < 10f) {
                    currentEnemy.GetComponent<AIMoveTorward>().hasEngaged = true;
                }
            }
        }

    }
}
