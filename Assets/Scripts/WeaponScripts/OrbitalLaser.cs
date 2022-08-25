using System.Collections;
using UnityEngine;

public class OrbitalLaser : ProjectileWeapon {
    private Transform _playerPosition;
    private Vector3 _enemyPosition;
    public GameObject explosion;
    private void FixedUpdate() {
        CanFireTimer();
        _playerPosition = GameObject.FindWithTag("Player").transform;
        if (GameObject.FindWithTag("Enemy")) {
            _enemyPosition = GameObject.FindWithTag("Enemy").transform.position;
        }
    }
    public override void FireWeapon(Vector3 firePoint, Vector3 targetPosition) {
        float startX = _enemyPosition.x;
        float startY = _enemyPosition.y;
        Transform bulletTransform = Instantiate(projectile, new Vector3(startX, 50, 0), Quaternion.identity);
        StartCoroutine(BeamCo(bulletTransform));
        Projectile bullet = bulletTransform.GetComponent<Projectile>();
        nextFire = Time.time + rateOfFire;
    }

    IEnumerator BeamCo(Transform bulletTransform) {
        float distance = Vector3.Distance(bulletTransform.position, _enemyPosition);
        GameObject explosionTransform = Instantiate(explosion, _enemyPosition, Quaternion.identity);
        StartCoroutine(ExplodeCo(explosionTransform));
        audioSource.Play();
        float time = 0;
        while (time < 1) {
            Debug.Log("this is the current time: " + (time < 1));
            bulletTransform.localScale = new Vector3(Mathf.Lerp(2, 0, time / 1), distance + 5, 0);

            time += Time.deltaTime;
            yield return null;
        }
        Destroy(bulletTransform.gameObject);
    }

    IEnumerator ExplodeCo(GameObject explosion) {
        float currentY = explosion.transform.localScale.y;
        float currentX = explosion.transform.localScale.x;
        int lerpMax = 2;
        float time = 0;
        while (explosion.transform.localScale.x > 0.1f) {
            explosion.transform.localScale = new Vector3(Mathf.Lerp(currentX, 0, time / lerpMax), Mathf.Lerp(currentY, 0, time / lerpMax), 0);
            time += Time.deltaTime;
            yield return null;
        } 
        Destroy(explosion);
    }
}
