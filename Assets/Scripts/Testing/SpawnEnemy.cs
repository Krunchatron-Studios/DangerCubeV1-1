using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("Spawn Parameters")]
    [SerializeField] private float _waitTime;
    private float _nextSpawn;
    [SerializeField] private int _spawnQuantity;
    [Header("Game Objects")]
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _playerPosition;
    void Update()
    {
        if (Time.time > _nextSpawn)
        {
            _nextSpawn += _waitTime;
            for (int x = 0; x < _spawnQuantity; x++)
            {
                Spawn();
            }
        }
    }
    public void Spawn()
    {
        _playerPosition = GameObject.FindWithTag("Player").transform;

		float distance = _enemy.GetComponent<BaseEnemy>()._spawnDistance;

        float tempX = _playerPosition.position.x;
        float tempY = _playerPosition.position.y;

        int randomizer = Random.Range(1, 9);
        // swap out static proximity modifiers for declared proximity modifiers
        switch (randomizer)
        {
            case 1:
                tempX = _playerPosition.position.x + Random.Range(distance, distance + 10);
                tempY = _playerPosition.position.y + Random.Range(distance, distance + 10);
                break;
            case 2:
                tempX = _playerPosition.position.x + Random.Range(distance * -1, (distance + 10) * -1);
                tempY = _playerPosition.position.y + Random.Range(distance * -1, (distance + 10) * -1);
                break;
            case 3:
                tempX = _playerPosition.position.x + Random.Range(distance * -1, (distance + 10) * -1);
                tempY = _playerPosition.position.y + Random.Range(distance, distance + 10);
                break;
            case 4:
                tempX = _playerPosition.position.x + Random.Range(distance, distance + 10);
                tempY = _playerPosition.position.y + Random.Range(distance * -1, (distance + 10) * -1);
                break;
            case 5:
                tempX = _playerPosition.position.x + Random.Range(distance, distance + 10);
                break;
            case 6:
                tempX = _playerPosition.position.x + Random.Range(distance * -1, (distance + 10) * -1);
                break;
            case 7:
                tempY = _playerPosition.position.y + Random.Range(distance * -1, (distance + 10) * -1);
                break;
            case 8:
                tempY = _playerPosition.position.y + Random.Range(distance, distance + 10);
                break;
        }
        
        Instantiate(_enemy, new Vector3(tempX, tempY, 0), Quaternion.identity);
    }
}
