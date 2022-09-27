using System.Collections;
using UnityEngine;

public class OrbitalLaser : ProjectileWeapon {
    private Transform _playerPosition;
    public GameObject explosion;
    
    private void Update() {
        CanFireTimer();
    }

    public override void CanFireTimer() {
        canFire = false;
        if (Time.time > nextFire) {
            canFire = true;
            for (int i = 0; i < firingPoints.Count; i++) {
                if (firingPoints[i].activeInHierarchy) {
                    FireWeapon(firingPoints[i].transform.position, enemyTarget);
                }
            }
        }
    }
    public override void FireWeapon(Vector3 firePoint, Vector3 targetPosition) {
        Debug.Log(targetPosition);
        GameObject spawnedBullet = objectPooler.GetPooledGameObject();
        Projectile bullet = spawnedBullet.GetComponent<Projectile>();
        bullet.gameObject.SetActive(true);
        bullet.transform.position = new Vector3(enemyTarget.x, enemyTarget.y, 0);

        nextFire = Time.time + attackSpeed;
        StartCoroutine(BeamCo(bullet));
    }

    IEnumerator BeamCo(Projectile bullet) {
        float distance = Vector3.Distance(bullet.transform.position, enemyTarget);
        
        GameObject spawnedExplosion = PoolManager.pm.laserSwirlPool.GetPooledGameObject();
        Projectile explosion = spawnedExplosion.GetComponent<Projectile>();
        explosion.transform.localScale = new Vector3(1, 1, 1);
        explosion.gameObject.SetActive(true);
        explosion.transform.position = enemyTarget;
        StartCoroutine(ExplodeCo(explosion));
        
        audioSource.Play();
        
        float time = 0;
        while (time < 1) {
            bullet.transform.localScale = new Vector3(Mathf.Lerp(2, 0, time / 1), distance + 5, 0);
            time += Time.deltaTime;
            yield return null;
        }
        bullet.gameObject.SetActive(false);
    }

    IEnumerator ExplodeCo(Projectile explosion) {
        var localScale = explosion.transform.localScale;
        float currentY = localScale.y;
        float currentX = localScale.x;
        int lerpMax = 2;
        float time = 0;
        while (explosion.transform.localScale.x > 0.1f) {
            explosion.transform.localScale = new Vector3(Mathf.Lerp(currentX, 0, time / lerpMax), Mathf.Lerp(currentY, 0, time / lerpMax), 0);
            time += Time.deltaTime;
            yield return null;
        } 
        explosion.gameObject.SetActive(false);
    }
}
