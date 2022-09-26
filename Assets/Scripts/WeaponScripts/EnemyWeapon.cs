using System.Collections;
using Managers;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour {

    public AudioSource audioSource;
    [Header("Player Position")]
    public GameObject playerPosition;
    public Vector3 aimPosition;
    
    [Header("Weapon Parameters")] 
    public float fireRange = 4.0f;
    public float reloadTimer = 3.0f;
    public float rateOfFire = 0.3f;
    public bool canFire = true;
    public float bulletSpeed = 10f;
    public int ammo = 3;
    public Transform barrel;
    [Header("Projectile Parameters")]
    public GameObject enemyProjectile;
    private Rigidbody2D _projectileBody;
    void FixedUpdate() {
        playerPosition = GameObject.FindWithTag("Player");
        aimPosition = playerPosition.transform.position;
        ShootPlayer();
    }

    public void ShootPlayer() {
        float distance = Vector3.Distance(playerPosition.transform.position, transform.position);
        if (distance <= fireRange && canFire) {
            canFire = false;
            StartCoroutine(UseWeapon());
        }
    }

    IEnumerator UseWeapon() {
        audioSource.Play();
        int currentAmmo = ammo;
        for (int i = 0; i < currentAmmo; i++) {
            GameObject bullet = EnemyPoolManager.epm.enemyBulletPool.GetPooledGameObject();
            bullet.SetActive(true);
            bullet.transform.position = barrel.position;
            _projectileBody = bullet.GetComponent<Rigidbody2D>();
            aimPosition.y -= .5f;
            Vector3 moveDirection = (aimPosition - transform.position).normalized;
            MoveProjectile(moveDirection);
            yield return new WaitForSeconds(rateOfFire);
        }
        yield return new WaitForSeconds(reloadTimer);
        canFire = true;
    }
    
    public void MoveProjectile(Vector3 direction) {
        _projectileBody.velocity = direction * bulletSpeed;
    }

    private void MuzzleFlash() {
        // GameObject flash = EnemyPoolManager.epm.mgFlashPool.GetPooledGameObject();
        // flash.SetActive(true);
        // flash.transform.position = barrel.position;
    }
}
