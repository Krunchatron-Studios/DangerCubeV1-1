using Interfaces;
using UnityEngine;
using MoreMountains.Tools;
using MoreMountains.Feedbacks;

public class PlayerLogic : MonoBehaviour, IHurtThingsInterface {
    public PlayerHealthAndShields healthAndShields;
    public GameObject player;
    
    public void TakeDamage(float damageAmount, string damageType) {
        player = GameObject.FindWithTag("Player");
        if (healthAndShields.playerShieldsCurrent > 0) {
            healthAndShields.playerShieldsCurrent -= damageAmount;
            MMFloatingTextSpawnEvent.Trigger(0, player.transform.position, 
                damageAmount.ToString(), Vector3.up, .3f);
            MMCameraShakeEvent.Trigger(.2f, .4f, 80, 0, 0, 0, false);
            Debug.Log("hit");
        } else if (healthAndShields.playerHealthCurrent <= 0) {
            Destroy(gameObject);
        }
    }
}