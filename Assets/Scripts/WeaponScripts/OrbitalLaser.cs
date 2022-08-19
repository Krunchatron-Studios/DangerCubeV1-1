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

        StartCoroutine(BeamCo(bulletTransform));
        
        Projectile bullet = bulletTransform.GetComponent<Projectile>();
        bullet.Setup(_enemyPosition);
        nextFire = Time.time + rateOfFire;
    }
    IEnumerator BeamCo(Transform bulletTransform) {
        int lerpMax = 2;
        float time = 0;
        while (time < lerpMax) {
            bulletTransform.localScale = new Vector3(2, Mathf.Lerp(50, _enemyPosition.y, time / lerpMax), 0);
            time += Time.deltaTime;
            yield return null;
        }
        Destroy(bulletTransform.gameObject);
    }
}
