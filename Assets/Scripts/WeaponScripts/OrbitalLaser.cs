using System.Collections;
using UnityEngine;

public class OrbitalLaser : ProjectileWeapon {
    private Transform _playerPosition;
    public GameObject explosion;
    private void FixedUpdate() {
        _playerPosition = GameObject.FindWithTag("Player").transform;
    }
    public override void FireWeapon(Vector3 firePoint, Vector3 targetPosition) {
        Debug.Log(targetPosition + " some fucking data");
        GameObject spawnedBullet = objectPooler.GetPooledGameObject();
        Projectile bullet = spawnedBullet.GetComponent<Projectile>();
        bullet.gameObject.SetActive(true);
        bullet.Setup(targetPosition);
        // bullet.transform.position = targetPosition;
        // bullet.transform.position = new Vector3(targetPosition);

        nextFire = Time.time + attackSpeed;
        StartCoroutine(BeamCo(bullet));
    }

    IEnumerator BeamCo(Projectile bullet) {
        float distance = Vector3.Distance(bullet.transform.position, enemyTarget);
        // GameObject explosionTransform = Instantiate(explosion, _enemyPosition, Quaternion.identity);
        // GameObject explosion = objectPooler.GetPooledGameObject();
        // Projectile explosion = this.explosion.GetComponent<Projectile>();
        // StartCoroutine(ExplodeCo(explosion));
        audioSource.Play();
        float time = 0;
        while (time < 1) {
            bullet.transform.localScale = new Vector3(Mathf.Lerp(2, 0, time / 1), distance + 5, 0);
            time += Time.deltaTime;
            yield return null;
        }
        bullet.gameObject.SetActive(false);
    }

    // IEnumerator ExplodeCo(Projectile explosion) {
    //     var localScale = explosion.transform.localScale;
    //     float currentY = localScale.y;
    //     float currentX = localScale.x;
    //     int lerpMax = 2;
    //     float time = 0;
    //     while (explosion.transform.localScale.x > 0.1f) {
    //         explosion.transform.localScale = new Vector3(Mathf.Lerp(currentX, 0, time / lerpMax), Mathf.Lerp(currentY, 0, time / lerpMax), 0);
    //         time += Time.deltaTime;
    //         yield return null;
    //     } 
    //     explosion.gameObject.SetActive(false);
    // }
}
