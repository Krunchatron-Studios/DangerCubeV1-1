using UnityEngine;

public class PlayerLogic : MonoBehaviour, IDmgAndHpInterface {
    public PlayerHealthAndShields healthAndShields;
    public void TakeDamage(float damageAmount, string damageType) {
        Debug.Log("In the damage dealer");
        if (healthAndShields.playerShieldsCurrent > 0) {
            healthAndShields.playerShieldsCurrent -= damageAmount;
        } else if (healthAndShields.playerHealthCurrent <= 0) {
            Destroy(gameObject);
        }
    }
}