using MoreMountains.Tools;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
    [Header("Spawn Parameters")]
    [SerializeField] private float waitTime;
    private float _nextSpawn;
    [SerializeField] private int spawnQuantity;
    [SerializeField] private int spawnDistance;
    [Header("Game Objects")]
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform playerPosition;

    public MMSimpleObjectPooler objectPooler;
    void Update() {
        if (Time.time > _nextSpawn) {
            _nextSpawn += waitTime;
            for (int x = 0; x < spawnQuantity; x++) {
                Spawn();
            }
        }
    }
    public void Spawn() {
        playerPosition = GameObject.FindWithTag("Player").transform;

		float distance = spawnDistance;

        float tempX = playerPosition.position.x;
        float tempY = playerPosition.position.y;

        int randomizer = Random.Range(1, 9);
        
        switch (randomizer) {
            case 1:
                tempX = playerPosition.position.x + Random.Range(distance, distance + 10);
                tempY = playerPosition.position.y + Random.Range(distance, distance + 10);
                break;
            case 2:
                tempX = playerPosition.position.x + Random.Range(distance * -1, (distance + 10) * -1);
                tempY = playerPosition.position.y + Random.Range(distance * -1, (distance + 10) * -1);
                break;
            case 3:
                tempX = playerPosition.position.x + Random.Range(distance * -1, (distance + 10) * -1);
                tempY = playerPosition.position.y + Random.Range(distance, distance + 10);
                break;
            case 4:
                tempX = playerPosition.position.x + Random.Range(distance, distance + 10);
                tempY = playerPosition.position.y + Random.Range(distance * -1, (distance + 10) * -1);
                break;
            case 5:
                tempX = playerPosition.position.x + Random.Range(distance, distance + 10);
                break;
            case 6:
                tempX = playerPosition.position.x + Random.Range(distance * -1, (distance + 10) * -1);
                break;
            case 7:
                tempY = playerPosition.position.y + Random.Range(distance * -1, (distance + 10) * -1);
                break;
            case 8:
                tempY = playerPosition.position.y + Random.Range(distance, distance + 10);
                break;
        }
        
        GameObject spawnedEnemy = objectPooler.GetPooledGameObject();
        spawnedEnemy.transform.position = transform.position;
        spawnedEnemy.SetActive(true);
    }
}