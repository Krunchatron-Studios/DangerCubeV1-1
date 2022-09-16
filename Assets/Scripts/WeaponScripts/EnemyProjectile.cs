using System.Collections;
using Interfaces;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
    public int enemyDamage;
    public float decayTimer = 3;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shield")) {
            IHurtThingsInterface hit = other.GetComponent<IHurtThingsInterface>();
            hit.TakeDamage(enemyDamage, "Physical");
            gameObject.SetActive(false);
        } else if (other.CompareTag("Wall")) {
            gameObject.SetActive(false);
        } else if (other.CompareTag("Obstacle")) {
            gameObject.SetActive(false);
        } 
        if (gameObject.activeInHierarchy) {
            StartCoroutine(BulletDecay());
        }
    }

    IEnumerator BulletDecay() {
        yield return new WaitForSeconds(decayTimer);
        gameObject.SetActive(false);
    }

    public void GetDamage(GameObject other) {
        IHurtThingsInterface hit = other.GetComponent<IHurtThingsInterface>();
        hit.TakeDamage(enemyDamage, "Physical");
    }
}
