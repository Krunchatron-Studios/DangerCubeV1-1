using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Health And Shields", menuName = "ScriptableObjects/PlayerHealthAndShields")]
public class PlayerHealthAndShields : ScriptableObject {
    public int playerShieldsMax;
    public int playerShieldsCurrent;
    public int playerHealthMax;
    public int playerHealthCurrent;

    void Start() {
        playerShieldsCurrent = playerShieldsMax;
        playerHealthCurrent = playerHealthMax;
    }
}
