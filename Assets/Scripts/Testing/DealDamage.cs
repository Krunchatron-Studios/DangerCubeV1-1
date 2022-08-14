using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    // can be deleted later
    [SerializeField] private int _healthMax;
    private int _currentHealth;
    [SerializeField] private Rigidbody2D _testBody;
    // end of future deletions
    void Start()
    {
        _currentHealth = _healthMax;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        int damage = collision.gameObject.GetComponent<BaseEnemy>()._damage;
        Debug.Log("this is how much damage is being passed: " + damage);
        if (collision.CompareTag("Enemy"))
        {
            StartCoroutine(DamageCo(damage));
        }
    }
    private IEnumerator DamageCo(int damage)
    {
        _currentHealth = _currentHealth - damage;
        yield return null;
        yield return new WaitForSeconds(1f);
        Debug.Log("This is the current health of the test object: " + _currentHealth);
    }
}
