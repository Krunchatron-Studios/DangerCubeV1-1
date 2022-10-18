using System.Collections;
using Managers;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour {

    public BaseEnemy weaponOwner;
    public AudioSource audioSource;
    
    [Header("Player Position")]
    public GameObject playerObject;
    
    [Header("Weapon Parameters")] 
    public float fireRange = 4.0f;
    public float reloadTimer = 3.0f;
    public float rateOfFire = 0.3f;
    public bool canFire = true;
    public float bulletSpeed = 10f;
    public int ammo = 3;
    [Header("Projectile Parameters")]
    public GameObject enemyProjectile;
    private Rigidbody2D _projectileBody;
    
    
    void FixedUpdate() {
        playerObject = GameObject.FindWithTag("Player");
        ShootPlayer();
    }

    public void ShootPlayer() {
        float distance = Vector3.Distance(playerObject.transform.position, transform.position);
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
            
            bullet.SetActive(true);
            bullet.transform.position = transform.position;
            muzzle.SetActive(true);
            muzzle.transform.position = transform.position;
            
            _projectileBody = bullet.GetComponent<Rigidbody2D>();
            Vector3 enemyAimAdjust = (playerObject.transform.position);
            enemyAimAdjust.y -= .5f;
            Vector3 moveDirection = (playerObject.transform.position - transform.position).normalized;
            MoveProjectile(moveDirection);
            yield return new WaitForSeconds(rateOfFire);
        }
        yield return new WaitForSeconds(reloadTimer);
        canFire = true;
    }
    
    public void MoveProjectile(Vector3 direction) {
        _projectileBody.velocity = direction * bulletSpeed;
    }
}
