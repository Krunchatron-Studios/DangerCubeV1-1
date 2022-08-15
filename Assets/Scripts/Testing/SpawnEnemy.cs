using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private float _waitTime;
    private float _nextSpawn;
    [SerializeField] private int _spawnQuantity;
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
    private void Spawn()
    {
        _playerPosition = GameObject.FindWithTag("Player").transform;
        float tempX = _playerPosition.position.x + Random.Range(10.0f, 20.0f);
        float tempY = _playerPosition.position.y + Random.Range(10.0f, 20.0f);
        Debug.Log(tempX + "/" + tempY);
        Instantiate(_enemy, new Vector3(tempX, tempY, 0), Quaternion.identity);
    }
}
