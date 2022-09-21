using Interfaces;
using UnityEngine;

public class PowerUp : Upgrade {
	[Header("POWER UP ONLY VARIABLES")]
	public Upgrade upgradeTarget;
	[Header("Stats to Increase")] 
	public float weaponDamage;
	public float attackSpeed;
	public float knockBack;
	public float projScale;
	public float projSpeed;
	public string damageType;
	public float reloadSpeed;
	public int ammoAmount;
	public int rangeAmount;
	private void Awake() {
		IUpgradeThingInterface other = upgradeTarget.gameObject.GetComponent<IUpgradeThingInterface>();
		
		other.IncreaseDamage(weaponDamage);
		other.IncreaseAttackSpeed(attackSpeed);
		other.IncreaseKnock(knockBack);
		other.ModifyDmgType(damageType);
		other.ImproveReloadTimer(reloadSpeed);
		other.IncreaseAmmoClipSize(ammoAmount);
		other.IncreaseRange(rangeAmount);
	}
}
