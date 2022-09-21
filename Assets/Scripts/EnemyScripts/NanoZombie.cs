using System.Collections;
using Interfaces;
using MoreMountains.Tools;
using UnityEngine;

public class NanoZombie : MonoBehaviour {
    private Vector3 _target;
    private int _moveSpeed = 1;
    private int _damage = 1;
    public int lifeTime = 5;
    public int chaseRadius = 3;
    public GameObject bloodSplash;
    public int currentZombies = 0;
    void Awake() {
        StartCoroutine(ZombieLife());
    }
    private void Update() {
        ChaseEnemy();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            MMFloatingTextSpawnEvent.Trigger(0, other.attachedRigidbody.transform.position, 
                _damage.ToString(), Vector3.up, .2f);
            IHurtThingsInterface hit = other.GetComponent<IHurtThingsInterface>();
            hit.TakeDamage(_damage, "Physical");
            bloodSplash = PoolManager.pm.bloodPool.GetPooledGameObject();
            bloodSplash.SetActive(true);
            bloodSplash.transform.position = other.transform.position;
        }
    }

    private void ChaseEnemy() {
        Collider2D foundObject = Physics2D.OverlapCircle(transform.position, chaseRadius);
        if (foundObject.CompareTag("Enemy")) {
            _target = foundObject.transform.position;
            MoveTowards();
        }
    }

    private void MoveTowards() {
        transform.position = Vector3.MoveTowards(transform.position, _target, _moveSpeed);
    }

    IEnumerator ZombieLife() {
        yield return null;
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
        currentZombies--;
    }
}
