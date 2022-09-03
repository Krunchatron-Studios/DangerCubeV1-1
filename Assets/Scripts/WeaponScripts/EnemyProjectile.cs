using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
    public int enemyDamage;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
            hit.TakeDamage(enemyDamage, "Physical");
            gameObject.SetActive(false);
        } else if (other.CompareTag("Wall")) {
            gameObject.SetActive(false);
            
        }
    }
}
