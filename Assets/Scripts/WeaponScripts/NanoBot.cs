using UnityEngine;

public class NanoBot : Projectile {
    public NanoManager nanoManager;
    private Vector3 _playerPosition;
    private Vector3 _anchorPoint;
    private Vector3 _nanoTransform;
    private GameObject _target;
    private float rotationSpeed = 50;
    [Header("Mutatation Payload")]
    public NanoZombie zombie;

    private void Start() {
        _nanoTransform = transform.position;
        _playerPosition = GameObject.FindWithTag("Player").transform.position;
    }

    private void FixedUpdate() {
        _playerPosition = GameObject.FindWithTag("Player").transform.position;
        _nanoTransform = transform.position;
        RotateNanos();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy") && other.gameObject.name == "Pedestrian(Clone)") {
            Destroy(other);
            Destroy(gameObject);
            if (nanoManager.currentNanoBots >= 1) {
                nanoManager.currentNanoBots--;
            }
        }
    }
    private void RotateNanos() {
        Vector3 move = new Vector3(0, 0, 1);
        transform.RotateAround(_playerPosition, move, rotationSpeed * Time.deltaTime);
        // _anchorPoint = (_nanoTransform - _playerPosition).normalized * 3 + _playerPosition;
        // transform.position = Vector3.MoveTowards(_nanoTransform, _anchorPoint, 0.5f);
    }
    private void OnDestroy() {
        Instantiate(zombie, _nanoTransform, Quaternion.identity);
    }
}
