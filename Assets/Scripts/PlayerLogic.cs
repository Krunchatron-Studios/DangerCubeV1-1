using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour, IDmgAndHpInterface {
    public PlayerHealthAndShields healthAndShields;
    public void TakeDamage(int damageAmount) {
        Debug.Log("In the damage dealer");
        if (healthAndShields.playerShieldsCurrent > 0) {
            healthAndShields.playerShieldsCurrent -= damageAmount;
        } else if (healthAndShields.playerHealthCurrent > 0) {
            healthAndShields.playerHealthCurrent -= damageAmount;
        } else if (healthAndShields.playerHealthCurrent <= 0) {
            //change reference to player object
            // Destroy(gameObject);
        }
    }
}