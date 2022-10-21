using System.Collections;
using Managers;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour {

    public BaseEnemy weaponOwner;
    public AudioSource audioSource;

    [Header("Weapon Parameters")] 
    public float fireRange = 4.0f;
    public float reloadTimer = 3.0f;
    public float rateOfFire = 0.3f;
    public bool canFire = true;
    public float bulletSpeed = 10f;
    public int ammo = 3;
    
    [Header("Projectile Parameters")] 
    public GameObject firePoint;
    public GameObject enemyProjectile;
    private Rigidbody2D _projectileBody;
    public Vector2 moveDirection;
    
    void FixedUpdate() {
        if (weaponOwner.playerObject) {
            moveDirection = (weaponOwner.playerObject.transform.position - transform.position).normalized;
            ShootPlayer();
        }
    }

    public void ShootPlayer() {
        float distance = Vector3.Distance(weaponOwner.playerObject.transform.position, transform.position);
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
            GameObject muzzle = EnemyPoolManager.epm.machineGunMuzzle.GetPooledGameObject();

            transform.localScale = new Vector2(
                weaponOwner.transform.localScale.x, 
                weaponOwner.transform.localScale.y);
            
            bullet.SetActive(true);
            bullet.transform.position = firePoint.transform.position;
            muzzle.SetActive(true);
            muzzle.transform.position = firePoint.transform.position;

            _projectileBody = bullet.GetComponent<Rigidbody2D>();
            
            
            EnemyAim();
            MoveProjectile(moveDirection);
            yield return new WaitForSeconds(rateOfFire);
        }
        yield return new WaitForSeconds(reloadTimer);
        canFire = true;
    }
    
    public void MoveProjectile(Vector3 direction) {
        _projectileBody.velocity = direction * bulletSpeed;
    }

    private void EnemyAim() {
        Vector3 enemyAimAdjust = new Vector3(
            weaponOwner.playerObject.transform.position.x, 
            weaponOwner.playerObject.transform.position.y, 
            weaponOwner.playerObject.transform.position.z);
        enemyAimAdjust.y -= .5f;
    }
}
