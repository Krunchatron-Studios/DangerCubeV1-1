using UnityEngine;

public class EnemyWeapon : MonoBehaviour {

    [Header("Main Weapon Vars")]
    public int weaponDamage = 1;
    public float weaponRange = 3;
	
    [Header("Firing Vars")]
    public float rateOfFire = 1.0f;
    public bool canFire = true;
    public float nextFire;
	
    [Header("Projectile Vars")]
    public Transform projectile;
    public Vector2 player;
    public TargetingSystem targetingSys;

    private void FixedUpdate() {
        CanFireTimer();
    }
    public void FireWeapon(Vector3 firePoint, Vector3 targetPosition) {
        Transform bulletTransform = Instantiate(projectile, firePoint, Quaternion.identity);
        Projectile bullet = bulletTransform.GetComponent<Projectile>();
        bullet.Setup(targetPosition);
        nextFire = Time.time + rateOfFire;
        bullet.MoveProjectile();
    }

    public void CanFireTimer() {
        canFire = false;
        if (Time.time > nextFire) {
            canFire = true;
            FireWeapon(transform.position, player);
        }
    }
    //
    // public void AquireTarget(BaseEnemy enemy) {
    //     enemyTarget = enemy.transform.position;
    // }
}