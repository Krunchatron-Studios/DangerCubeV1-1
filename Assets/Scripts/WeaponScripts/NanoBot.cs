using UnityEngine;

public class NanoBot : Projectile {
    public NanoManager nanoManager;
    public GameObject rotationCenter;
    private Vector3 _nanoTransform;
    [Header("Mutation Payload")]
    public NanoZombie zombie;

    private void Update() {
        _nanoTransform = transform.position;
        transform.RotateAround(rotationCenter.transform.position, Vector3.forward, projectileVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy") && other.gameObject.name == "Pedestrian(Clone)") {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
            OnDestroy();
            if (nanoManager.currentNanoBots >= 1) {
                nanoManager.currentNanoBots--;
            }
        }
    }
    private void OnDestroy() {
        Instantiate(zombie, _nanoTransform, Quaternion.identity);
    }
}
