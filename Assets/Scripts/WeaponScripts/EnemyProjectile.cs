using System.Collections;
using Interfaces;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
    public int enemyDamage;
    public float decayTimer = 3;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            IHurtThingsInterface hit = other.GetComponent<IHurtThingsInterface>();
            hit.TakeDamage(enemyDamage, "Physical");
            gameObject.SetActive(false);
        } else if (other.CompareTag("Wall")) {
            gameObject.SetActive(false);
        }

        if (gameObject.activeInHierarchy) {
            StartCoroutine(bulletDecay());

        }
    }

    IEnumerator bulletDecay() {
        yield return new WaitForSeconds(decayTimer);
        gameObject.SetActive(false);
    }
}
