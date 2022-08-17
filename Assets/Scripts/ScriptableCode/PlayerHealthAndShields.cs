using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Health And Shields", menuName = "ScriptableObjects/PlayerHealthAndShields")]
public class PlayerHealthAndShields : ScriptableObject {
    public float playerShieldsMax;
    public float playerShieldsCurrent;
    public float playerHealthMax;
    public float playerHealthCurrent;

    void Start() {
        playerShieldsCurrent = playerShieldsMax;
        playerHealthCurrent = playerHealthMax;
    }
}
