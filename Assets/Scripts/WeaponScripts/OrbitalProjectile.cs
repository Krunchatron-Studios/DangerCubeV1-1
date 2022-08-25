using UnityEngine;

public class OrbitalProjectile : MonoBehaviour {

    public Weapon weapon;
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            IDmgAndHpInterface hit = other.GetComponent<IDmgAndHpInterface>();
            hit.TakeDamage(weapon.weaponDamage);
        }
        if (other.CompareTag("Wall")) {
        }
    }
}
