using UnityEngine;

public class MutagenicNanobots : Weapon {
    public NanoManager nanoManager;
    private GameObject _playerPosition;
    private Vector3 _center;
    public GameObject nanoBot;
    public float spawnDelay;

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
                //Instantiate(nanoBot, offset, Quaternion.identity);
                GameObject nano = PoolManager.pm.nanoPool.GetPooledGameObject();
                nano.SetActive(true);
                nano.transform.position = offset;
                nanoManager.currentNanoBots++;
            }
        }
    }
}
