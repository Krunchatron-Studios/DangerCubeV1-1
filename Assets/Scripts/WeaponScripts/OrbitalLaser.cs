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
        Transform bulletTransform = Instantiate(projectile, new Vector3(startX, 50, 0), Quaternion.identity);
        StartCoroutine(BeamCo(bulletTransform));
        Projectile bullet = bulletTransform.GetComponent<Projectile>();
        nextFire = Time.time + rateOfFire;
    }

    IEnumerator BeamCo(Transform bulletTransform) {
        audioSource.Play();
        int lerpMax = 2;
        // float time = 0;
        for (float time = 0; time <= lerpMax; time += 0.5f) {
            bulletTransform.localScale = new Vector3(2, Mathf.Lerp(50, _enemyPosition.y, time / lerpMax), 0);
            // time += Time.deltaTime;
            yield return null;
        }
   
        Debug.Log("made it here");
        GameObject explosionTransform = Instantiate(explosion, _enemyPosition, Quaternion.identity);

        StartCoroutine(ExplodeCo(explosionTransform));
        Destroy(bulletTransform);
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
