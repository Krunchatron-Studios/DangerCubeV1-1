using UnityEngine;

public class RapidFireWeapon : ProjectileWeapon {
	
	[Header("Rapid fire weapon exclusive stats")]
	public bool isRapidFiring;
	public float weaponCoolDown;
	[SerializeField] private float longRof = 3;
	[SerializeField] private float fastRof = 1;
	
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
		bool rapidFireTimerTriggered = false;
		
		if (!isRapidFiring) {
			attackSpeed = fastRof;
			isRapidFiring = true;
			rapidFireTimerTriggered = true;
		}
		
		if (isRapidFiring && !rapidFireTimerTriggered) {
			attackSpeed = longRof;
			isRapidFiring = false;
		}
	}
}
