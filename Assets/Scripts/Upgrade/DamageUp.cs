
public class DamageUp : PowerUp {
	public Weapon parentWeapon;
	public float powerUpAmount;
	private void OnEnable() {
		ResolvePowerUp(powerUpAmount);
		parentWeapon.IncreaseDamage(powerUpAmount);
	}
	public void ResolvePowerUp(float dmgIncrease) {
		weaponControls.IncreaseDamage(dmgIncrease);		
	}

}
