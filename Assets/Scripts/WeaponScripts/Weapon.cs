using UnityEngine;
using MoreMountains.Feedbacks;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour {

	public Sprite weaponSprite;
	private AudioClip weaponSound;
	public AudioSource audioSource;
	
	[Header("Main Weapon Vars")]
	public string weaponName;
	public string weaponDescription;
	public int weaponDamage = 1;
	public float weaponRange = 3;
	
	[Header("Firing Vars")]
	public int weaponLevel = 1;
	public float rateOfFire = 2.0f;
	private float originalRof;
	public bool isRapidFiring;
	public bool canFire = true;
	public float nextFire;
	public float weaponCoolDown;
	
	[Header("Projectile Vars")]
	public GameObject[] firePointArray;
	public Transform projectile;
	public Vector2 enemyTarget;
	
	[Header("Upgrade Related")]
	public string[] weaponUpgrades;
	public TargetingSystem targetingSys;

	private void Start() {
		audioSource = GetComponent<AudioSource>();
		originalRof = rateOfFire;
	}

	private void FixedUpdate() {
		CanFireTimer();

		if (Time.time > weaponCoolDown) {
			RapidFireTimer();
			weaponCoolDown = Time.time + 2;
		}
			
			
		
		
	}
	public virtual void FireWeapon(Vector3 firePoint, Vector3 targetPosition) {
		audioSource.Play();
		Transform bulletTransform = Instantiate(projectile, firePoint, Quaternion.identity);
		Projectile bullet = bulletTransform.GetComponent<Projectile>();
		bullet.Setup(targetPosition);
		nextFire = Time.time + rateOfFire;
		bullet.MoveProjectile();
		MMCameraShakeEvent.Trigger(.1f, .2f, 40, 0, 0, 0, false);
	}

	public void CanFireTimer() {
		canFire = false;
		if (Time.time > nextFire) {
			canFire = true;
			for (int i = 0; i < firePointArray.Length; i++) {
				if (firePointArray[i].activeInHierarchy) {
					FireWeapon(firePointArray[i].transform.position, enemyTarget);

				}
			}
		}
	}

	public void AquireTarget(BaseEnemy enemy) {
		enemyTarget = enemy.transform.position;
	}

	public void RapidFireTimer() {
		bool RapidFireTimerTriggered = false;
		
			if (!isRapidFiring) {
				rateOfFire = .15f;
				isRapidFiring = true;
				Debug.Log($"time: {Time.time}");
				RapidFireTimerTriggered = true;
			}
		
			if (isRapidFiring && !RapidFireTimerTriggered) {
				rateOfFire = 1f;
				isRapidFiring = false;
				Debug.Log($"weaponCD: {weaponCoolDown}");
			}
	}
}
