using UnityEngine;

public class RapidFireWeapon : ProjectileWeapon {
	
	[Header("Rapid fire weapon exclusive stats")]
	public bool isRapidFiring;
	public float weaponCoolDown;

	private void Start() {
		weaponCoolDown = Time.time + 2;
	}
	private void FixedUpdate() {
		CanFireTimer();
		if (Time.time > weaponCoolDown) {
			RapidFireTimer();
			weaponCoolDown = Time.time + 2;
		}
	}
	
	public void RapidFireTimer() {
		Debug.Log("we made it!");
		bool rapidFireTimerTriggered = false;
		
		if (!isRapidFiring) {
			rateOfFire = .15f;
			isRapidFiring = true;
			Debug.Log($"time: {Time.time}");
			rapidFireTimerTriggered = true;
		}
		
		if (isRapidFiring && !rapidFireTimerTriggered) {
			rateOfFire = 1f;
			isRapidFiring = false;
			Debug.Log($"weaponCD: {weaponCoolDown}");
		}
	}
}
