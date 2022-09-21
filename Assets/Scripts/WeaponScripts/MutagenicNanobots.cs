using UnityEngine;

public class MutagenicNanobots : Weapon {
    public int maxNanos;
    public int currentNanos;
    private GameObject _playerPosition;
    public int distance;
    public NanoBot[] nanoBots;

    void Start() {
        currentNanos = 0;
        InvokeRepeating("SpawnNanos", 2f, attackSpeed);
    }
    void FixedUpdate() {
        _playerPosition = GameObject.FindWithTag("Player");
    }

    private void SpawnNanos() {
        if (currentNanos < maxNanos) {
            int temp = currentNanos;
            int index = 0;
            while (currentNanos != temp + 1) {
                if (nanoBots[index].gameObject.activeInHierarchy == false) {
                    transform.position = new Vector3(0, distance, 0) + _playerPosition.transform.position;
                    nanoBots[index].gameObject.SetActive(true);
                    currentNanos++;
                }
                else {
                    index++;
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
