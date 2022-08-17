using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalLaser : Weapon {
    private Transform _playerPosition;
    private GameObject[] _allEnemies;
    private Vector3 _enemyPosition;
    private int _random;
    private void FixedUpdate() {
        CanFireTimer();
        _allEnemies = (GameObject[]) GameObject.FindGameObjectsWithTag("Enemy");
        _random = Random.Range(0, _allEnemies.Length - 1);
        // Debug.Log(_random);
        _playerPosition = GameObject.FindWithTag("Player").transform;
    }
    public override void FireWeapon(Vector3 firePoint, Vector3 targetPosition) {
        
        if (_allEnemies.Length > 0 && _random >= 0 && _random <= _allEnemies.Length - 1) {
            _enemyPosition = _allEnemies[_random].transform.position;
        }
        Debug.Log(_enemyPosition + " enemy position");
        // Debug.Log(_random);
        // Debug.Log(_allEnemies[0]);
        float startX = _enemyPosition.x;
        float startY = _playerPosition.position.y + 20;
        
        // starting in the right position
        Transform bulletTransform = Instantiate(projectile, new Vector3(startX, 50, 0), Quaternion.identity);
        float difference = bulletTransform.position.y + _enemyPosition.y;
        // Debug.Log("This is y difference: " + difference);
        bulletTransform.localScale = new Vector3(1, difference, 1);

        Projectile bullet = bulletTransform.GetComponent<Projectile>();
        bullet.Setup(_enemyPosition);
        _nextFire = Time.time + rateOfFire;
    }
}
