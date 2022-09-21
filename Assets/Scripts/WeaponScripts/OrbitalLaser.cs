using System.Collections;
using UnityEngine;

public class OrbitalLaser : ProjectileWeapon {
    private Transform _playerPosition;
    private Vector3 _enemyPosition;
    public GameObject explosion;
    private void FixedUpdate() {
        CanFireTimer();
        _playerPosition = GameObject.FindWithTag("Player").transform;
        _enemyPosition = targetingSys.weapon.GetComponent<ProjectileWeapon>().enemyTarget;
        // if (GameObject.FindWithTag("Enemy")) {
        //     _enemyPosition = GameObject.FindWithTag("Enemy").transform.position;
        //     Debug.Log($"enemy position: {_enemyPosition}");
        // }
    }
    public override void FireWeapon(Vector3 firePoint, Vector3 targetPosition) {
        GameObject bulletTransform = Instantiate(projectile, _enemyPosition, Quaternion.Euler(0,0,90));
        StartCoroutine(BeamCo(bulletTransform));
        Projectile bullet = bulletTransform.GetComponent<Projectile>();
        nextFire = Time.time + attackSpeed;
    }

    IEnumerator BeamCo(GameObject bulletTransform) {
        float distance = Vector3.Distance(bulletTransform.transform.position, _enemyPosition);
        GameObject explosionTransform = Instantiate(explosion, _enemyPosition, Quaternion.identity);
        StartCoroutine(ExplodeCo(explosionTransform));
        audioSource.Play();
        float time = 0;
        while (time < 1) {
            bulletTransform.transform.localScale = new Vector3(Mathf.Lerp(2, 0, time / 1), distance + 5, 0);
            time += Time.deltaTime;
            yield return null;
        }
        Destroy(bulletTransform.gameObject);
    }

    IEnumerator ExplodeCo(GameObject laserSwirl) {
        var localScale = laserSwirl.transform.localScale;
        float currentY = localScale.y;
        float currentX = localScale.x;
        int lerpMax = 2;
        float time = 0;
        while (laserSwirl.transform.localScale.x > 0.1f) {
            laserSwirl.transform.localScale = new Vector3(Mathf.Lerp(currentX, 0, time / lerpMax), Mathf.Lerp(currentY, 0, time / lerpMax), 0);
            time += Time.deltaTime;
            yield return null;
        } 
        Destroy(laserSwirl);
    }
}
