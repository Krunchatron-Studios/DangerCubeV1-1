using UnityEngine;

public class MutagenicNanobots : ProjectileWeapon {
    public int maxNanos;
    public int currentNanos;
    private GameObject _playerPosition;
    public int distance;
    public NanoBot[] nanoBots;

    void Start() {
        currentNanos = 0;
        InvokeRepeating(nameof(SpawnNanos), upgradeRange, attackSpeed);
    }
    void FixedUpdate() {
        _playerPosition = GameObject.FindWithTag("Player");
    }

    private void SpawnNanos() {
        if (currentNanos < maxNanos) {
            bool nanoFound = false;
            int temp = currentNanos;
            for(int i = 0; i < nanoBots.Length; i++) {
                if (!nanoBots[i].gameObject.activeInHierarchy && !nanoFound) {
                    transform.position = new Vector3(0, distance, 0) + _playerPosition.transform.position;
                    nanoBots[i].gameObject.SetActive(true);
                    nanoFound = true;
                    currentNanos++;
                }
            }
        }
    }
    public override void IncreaseAmmoClipSize(int ammoBonus) {
        maxNanos += ammoBonus;
    }
    public override void IncreaseRange(int amountToIncrease) {
        distance += amountToIncrease;
    }
}
