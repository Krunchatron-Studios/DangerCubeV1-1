using UnityEngine;

public class NanoBot : Projectile {
    public NanoManager nanoManager;
    public GameObject rotationCenter;
    // private Vector3 _anchorPoint;
    // private Vector3 _nanoTransform;
    // private GameObject _target;
    public float rotationSpeed = 50;
    [Header("Mutation Payload")]
    public NanoZombie zombie;

    private void Update() {
        // rotationCenter = GameObject.FindWithTag("Player").transform;
        // _nanoTransform = transform.position;
        transform.RotateAround(rotationCenter.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy") && other.gameObject.name == "Pedestrian(Clone)") {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
            if (nanoManager.currentNanoBots >= 1) {
                nanoManager.currentNanoBots--;
            }
        }
    }
    // private void OnDestroy() {
    //     Instantiate(zombie, _nanoTransform, Quaternion.identity);
    // }
}
