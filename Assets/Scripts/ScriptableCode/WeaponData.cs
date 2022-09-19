using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData")]
    public class WeaponData : ScriptableObject {

        public float weaponDamage;
        public float attackSpeed;
        public string damageType;
        public float knockForce;
        public float reloadTimer = 2.0f;
        public int ammo = 5;
        public GameObject firingPoint;
        public GameObject projectile;
        public Vector2 enemyTarget;
        public TargetingSystem targetingSys;
        
        public float weaponDamageInit;
        public float attackSpeedInit;
        public string damageTypeInit;
        public float knockForceInit;
        public float reloadTimerInit = 2.0f;
        public int ammoInit = 5;
        public GameObject firingPointInit;
        public GameObject projectileInit;
        public Vector2 enemyTargetInit;
        public TargetingSystem targetingSysInit;

        private void Start() {
	        weaponDamage = weaponDamageInit;
	        attackSpeed = attackSpeedInit;
	        damageType = damageTypeInit;
	        knockForce = knockForceInit;
	        reloadTimer = reloadTimerInit;
	        ammo = ammoInit;
	        firingPoint = firingPointInit;
	        projectile = projectileInit;
	        enemyTarget = enemyTargetInit;
	        targetingSys = targetingSysInit;

        }
}
