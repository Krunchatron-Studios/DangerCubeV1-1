using UnityEngine;

public class MutagenicNanobots : Weapon {
    public NanoManager nanoManager;
    private GameObject _playerPosition;
    public int distance;
    public NanoBot[] nanoBots;

    void Start() {
        nanoManager.currentNanoBots = 0;
        InvokeRepeating("SpawnNanos", 2f, attackSpeed);
    }
    void FixedUpdate() {
        _playerPosition = GameObject.FindWithTag("Player");
    }

    private void SpawnNanos() {
        if (nanoManager.currentNanoBots < nanoManager.maxNanoBots) {
            if (nanoManager.currentNanoBots < nanoManager.maxNanoBots) {
                transform.position = new Vector3(0, distance, 0) + _playerPosition.transform.position;
                int index = nanoManager.currentNanoBots;
                nanoBots[index].gameObject.SetActive(true);
                nanoManager.currentNanoBots++;
            }
        }
    }
}
