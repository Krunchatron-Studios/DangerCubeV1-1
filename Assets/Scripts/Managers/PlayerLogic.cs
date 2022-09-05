using UnityEngine;
using MoreMountains.Tools;


public class PlayerLogic : MonoBehaviour, IDmgAndHpInterface {
    public PlayerHealthAndShields healthAndShields;
    public GameObject player;
    
    public void TakeDamage(float damageAmount, string damageType) {
        player = GameObject.FindWithTag("Player");
        if (healthAndShields.playerShieldsCurrent > 0) {
            healthAndShields.playerShieldsCurrent -= damageAmount;
            MMFloatingTextSpawnEvent.Trigger(0, player.transform.position, 
                damageAmount.ToString(), Vector3.up, .3f);
        } else if (healthAndShields.playerHealthCurrent <= 0) {
            Destroy(gameObject);
        }
    }
}