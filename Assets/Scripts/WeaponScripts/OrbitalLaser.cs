using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        _playerPosition = GameObject.FindWithTag("Player").transform;
    }
    public override void FireWeapon(Vector3 firePoint, Vector3 targetPosition) {
        
        if (_allEnemies.Length > 0 && _random >= 0 && _random <= _allEnemies.Length - 1) {
            _enemyPosition = _allEnemies[_random].transform.position;
        }
        
        Vector3 origin = new Vector3(_enemyPosition.x, 50, 1);
        Vector3 direction = (_enemyPosition - origin).normalized;
        float distance = Vector3.Distance(origin, _enemyPosition);

        float startX = _enemyPosition.x;
        
        Transform bulletTransform = Instantiate(projectile, new Vector3(startX, 50, 0), Quaternion.identity);
        float difference = bulletTransform.position.y + _enemyPosition.y;

        GrowBeam(bulletTransform, difference);

        Projectile bullet = bulletTransform.GetComponent<Projectile>();
        bullet.Setup(_enemyPosition);
        nextFire = Time.time + rateOfFire;
    }

    public async void GrowBeam(Transform bulletTransform, float difference) {
        float currentValue = 0;
        while (bulletTransform.localScale.y < difference) {
            // Debug.Log(currentValue);
            currentValue += 1;
            bulletTransform.localScale = new Vector3((float)2, (float)currentValue, 1);
            await Task.Delay(5);
        }
    }
}
