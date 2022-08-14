using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDmgAndHpInterface {
	public void TakeDamage(int dmgAmount);
	public void HealDamage(int healAmount);
}
