using UnityEngine;

public class MutagenicNanobots : Weapon {
    public NanoManager nanoManager;
    private GameObject _playerPosition;
    private Vector3 _center;
    public float spawnDelay;
    public NanoBot[] nanoBots;

    void Start() {
        _playerPosition = GameObject.FindWithTag("Player");
        _center = _playerPosition.transform.position;
        nanoManager.currentNanoBots = 0;
        InvokeRepeating("SpawnNanos", 2f, spawnDelay);
    }
    void FixedUpdate() {
        _playerPosition = GameObject.FindWithTag("Player");
        _center = _playerPosition.transform.position;
    }

    private void SpawnNanos() {
        if (nanoManager.currentNanoBots < nanoManager.maxNanoBots) {
            Vector3 offset = new Vector3(_center.x, _center.y + 3, 0);
            if (nanoManager.currentNanoBots < nanoManager.maxNanoBots) {
                Debug.Log("Nano created");
                int index = nanoManager.currentNanoBots;
                NanoBot nano = Instantiate(nanoBots[index]);
                // GameObject nano = objectPooler.GetPooledGameObject();
                // nano.SetActive(true);
                nano.transform.position = offset;
                nanoManager.currentNanoBots++;
            }
        }
    }
}
