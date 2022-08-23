using System.Collections;
using UnityEngine;

public class OrbitalLaser : Weapon {
    private Transform _playerPosition;
    private Vector3 _enemyPosition;
    public GameObject explosion;
    private void FixedUpdate() {
        CanFireTimer();
        _playerPosition = GameObject.FindWithTag("Player").transform;
        if (GameObject.FindWithTag("Enemy") != null) {
            _enemyPosition = GameObject.FindWithTag("Enemy").transform.position;
        }
    }
    public override void FireWeapon(Vector3 firePoint, Vector3 targetPosition) {
        audioSource.Play();
        float startX = _enemyPosition.x;
        Transform bulletTransform = Instantiate(projectile, new Vector3(startX, 50, 0), Quaternion.identity);
        StartCoroutine(BeamCo(bulletTransform));
        Projectile bullet = bulletTransform.GetComponent<Projectile>();
        bullet.Setup(_enemyPosition);
        nextFire = Time.time + rateOfFire;
    }

    public override void CanFireTimer() {
        canFire = false;
        if (Time.time > nextFire) {
            canFire = true;
            for (int i = 0; i < firePointArray.Length; i++) {
                if (firePointArray[0].activeInHierarchy) {
                    FireWeapon(firePointArray[0].transform.position, enemyTarget);
                }
            }
        }
    }
    IEnumerator BeamCo(Transform bulletTransform) {
        int lerpMax = 2;
        float time = 0;
        while (time < lerpMax) {
            bulletTransform.localScale = new Vector3(2, Mathf.Lerp(50, _enemyPosition.y, time / lerpMax), 0);
            time += Time.deltaTime;
            yield return null;
        }
        GameObject explosionTransform = Instantiate(explosion, _enemyPosition, Quaternion.identity);
        StartCoroutine(ExplodeCo(explosionTransform));
        Destroy(bulletTransform.gameObject);
    }

    IEnumerator ExplodeCo(GameObject explosion) {
        Vector3 currentScale = explosion.transform.localScale;
        float currentY = currentScale.y;
        float currentX = currentScale.x;
        int lerpMax = 2;
        float time = 0;
        while (explosion.transform.localScale.x > 0.1f) {
            currentScale = new Vector3(Mathf.Lerp(currentX, 0, time / lerpMax), Mathf.Lerp(currentY, 0, time / lerpMax), 0);
            time += Time.deltaTime;
            yield return null;
        } 
        Destroy(explosion);
    }

    private void FindPlayerAndEnemyPos() {
        _playerPosition = GameObject.FindWithTag("Player").transform;
        if (GameObject.FindWithTag("Enemy") != null) {
            _enemyPosition = GameObject.FindWithTag("Enemy").transform.position;
        }
    }
}
